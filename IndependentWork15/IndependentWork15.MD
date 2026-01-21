 # Самостійна робота №15

## Звіт з аналізу SOLID принципів (SRP, OCP) в Open-Source проєкті

## 1. Обраний проєкт

AutoMapper: 
[GitHub](https://github.com/LuckyPennySoftware/AutoMapper/tree/main).

## 2. Аналіз SRP (Single Responsibility Principle)

### 2.1. Приклади дотримання SRP

#### Клас: `AddProfiles`

-   Цей клас це Unit-тест. Клас має в собі два ізольовані класи `ForwardProfile` та `ReverseProfile`. Кожен із цих класів включно із `AddProfiles` не порушують привала SRP, тому що кожен із них виконує тільки по одній задачі. `AddProfiles` відповідає тільки за тестування профілів.

```csharp
public class AddProfiles : AutoMapperSpecBase
{
    public class Source { }
    public class Dest { }
    public class ForwardProfile : Profile
    {
        public ForwardProfile() => CreateMap<Source, Dest>();
    }
    public class ReverseProfile : Profile
    {
        public ReverseProfile() => CreateMap<Dest, Source>();
    }
    protected override MapperConfiguration CreateConfiguration() => new(c => c.AddProfiles(new Profile[] { new ForwardProfile(), new ReverseProfile() }));
    [Fact]
    public void Should_not_throw_when_loading_multiple_profiles() => GetProfiles().Count().ShouldBe(3); // default plus two specifically added
}
```

#### Клас: `ForPath`
-   Ще один клас із ізольованими класами в середині. `Order` зберігає дані замовлення, `OrderDto` DTO для передачі даних і т.д. Сам клас `ForPath` має метод `Should_unflatten` який перевіряє що мапінг працює.
```csharp
public class ForPath : AutoMapperSpecBase
{
    public class Order
    {
        public CustomerHolder CustomerHolder { get; set; }
    }

    public class CustomerHolder
    {
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderDto
    {
        public string CustomerName { get; set; }
        public decimal Total { get; set; }
    }

    protected override MapperConfiguration CreateConfiguration() => new(cfg =>
    {
        cfg.CreateMap<OrderDto, Order>()
            .ForPath(o=>o.CustomerHolder.Customer.Name, o=>o.MapFrom(s=>s.CustomerName))
            .ForPath(o => o.CustomerHolder.Customer.Total, o => o.MapFrom(s => s.Total));
    });

    [Fact]
    public void Should_unflatten()
    {
        var dto = new OrderDto { CustomerName = "George Costanza", Total = 74.85m };
        var model = Mapper.Map<Order>(dto);
        model.CustomerHolder.Customer.Name.ShouldBe("George Costanza");
        model.CustomerHolder.Customer.Total.ShouldBe(74.85m);
    }
}
```

### 2.2. Приклади порушення SRP

#### Клас `ServiceProviderTests`

Цей клас бере на себе багато відповідальності, наприклад такі як: 

- Конфігураця DI контейнера.
- Ініціалізація та модифікація бізнес логіки.
- Перевірка конфігурації.

У тестах таке часто допускається, але фактично це порушення SRP.

```csharp
public class ServiceProviderTests
{
    private readonly IServiceProvider _provider;

    public ServiceProviderTests()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddTransient<ISomeService>(sp => new FooService(5));
        services.AddSingleton<ILoggerFactory>(NullLoggerFactory.Instance);
        services.AddAutoMapper((sp, _) =>
        {
            var service = sp.GetRequiredService<ISomeService>();
            service.Modify(5);
        }, typeof(Source), typeof(Profile));
        _provider = services.BuildServiceProvider();

        _provider.GetService<IConfigurationProvider>().AssertConfigurationIsVali();
    }

    [Fact]
    public void ShouldResolveWithDependency()
    {
        var mapper = _provider.GetService<IMapper>();
        var dest = mapper.Map<Source2, Dest2>(new Source2());

        dest.ResolvedValue.ShouldBe(5);
    }

    [Fact]
    public void ShouldConvertWithDependency()
    {
        var mapper = _provider.GetService<IMapper>();
        var dest = mapper.Map<Source2, Dest2>(new Source2 { ConvertedValue = 5});

        dest.ConvertedValue.ShouldBe(10);
    }
}
```

## 3. Аналіз OCP (Open/Closed Principle)

### 3.1. Приклади дотримання OCP

#### Момент в коді: клас: `ServiceLifetimeTests`
-   Механіка розширення дозволена за допомогою інтрефейсу `ISingletonService`.
-   Дозволяє розширюватись за допомогою реалізації інтрефейсу.

`ISingletonService` реалізовується в класі `TestSingletonService`. Також можна додати нову реалізацію `AnotherSingletonService`, не змінюючи код тесту.

```csharp 
// Інтерфейс
internal interface ISingletonService
	{
		Bar DoTheThing(Foo theObj);
	}
```
```csharp 
// Клас який реалізує
internal class TestSingletonService : ISingletonService
	{
		private readonly IMapper _mapper;

		public TestSingletonService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public Bar DoTheThing(Foo theObj)
		{
			var bar = _mapper.Map<Bar>(theObj);
			return bar;
		}
	}
```

#### 3.2. Приклади порушення OCP

Нажаль не вдалось найти :(

## 4. Загальні висновки

В проєкті всі основні правила SOLID дотримані. SRP може бути порушене в unit-теста, що там допускається. OCP дуже добре дотримується, немаж моментів де воно порушується (або я сліпий, тому не знайшов).


