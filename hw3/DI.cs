// Використання DI
IWorkable workerHuman = new HumanWorker();

var menager = new WorkService(workerHuman);
menager.Menager();