using DeeULib;

namespace Programming.Classwork;

public class ClassworkEvents
{
   
    public class Worker 
    {
        protected WorkerStatus workerStatus;
        public int ID { get; set; }

        public bool IsAvailable = true;

        public WorkerStatus SetWorkerStatus(WorkerStatus status) => workerStatus = status;
        public WorkerStatus GetWorkerStatus() => workerStatus;
        
        public Worker(WorkerStatus status)
        {
            ID = -1;
            this.workerStatus = status;
        }

        public delegate void RequestVacation();

        public event RequestVacation SendRequestVacation;
        
        public List<Worker> ReplacementSheet;
        
        

        // protected virtual void OnSendRequestVacation(Company company)
        // {
        //     SendRequestVacation?.Invoke(company);
        // }
    }
    public class Manager : Worker
    {
        public Manager(WorkerStatus status) : base(status)
        {
            ID = -1;
        }
    }
    public class Company
    {
        private List<Worker> workers = new();
        
        public Worker? GetWorker(int id) => workers.Find(x => x.ID == id);

        public void AddNewWorker(Worker worker)
        {
            worker.ID = GenerateUID();
            workers.Add(worker);
            
            worker.SendRequestVacation += Hello;
        }

        public void VacationRequestHandler(Worker worker)
        {
            Worker.RequestVacation request;
            
        }

        public void Hello()
        {
        }

        private int GenerateUID()
        {
            if (workers.Count == 0) return 0;
            
            foreach(var id in Enumerable.Range(0, workers.Count+1))
                if (workers.All(x => x.ID != id))
                    return id;

            throw new Exception("Unable to generate UID");
        }
        
        public void RemoveWorker(int id) => workers.RemoveAt(workers.FindIndex(x => x.ID == id));
        public void Print() => string.Join(" ", workers.Select(x => x.ID)).Print();
        
        public int WorkersCount() => workers.Count(worker => worker.GetWorkerStatus() == WorkerStatus.Worker);
        public int ManagersCount() => workers.Count(worker => worker.GetWorkerStatus() == WorkerStatus.Manager);
    }
    
    
    public enum WorkerStatus
    {
        Worker,
        Manager
    }
}

