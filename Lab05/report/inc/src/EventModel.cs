class EventModel
{
	public EventModel(int _max_clients_n = 300)
	{
		clients = new Generator(8, 12);
		operators = new List<Service> { new Service(15, 25), new Service(30, 50), new Service(20, 60) };
		storages = new List<ReqQue> { new ReqQue(), new ReqQue()};
		computers = new List<Service> { new Service(15, 15), new Service(30, 30) };
		max_clients_n = _max_clients_n;
	}

	public double getRefuseProb()
	{
		reset();

		while (events.Count > 0)
		{
			BaseEvent e = events[0];
			events.RemoveAt(0);

			end_time = e.time;
			e.Handle(this);
		}

		return (double)refused_n / (refused_n + served_n);
	}

	public void addEvent(BaseEvent e)
	{
		events.Add(e);
		events.Sort();
	}






	public string getResultsStr()
	{
		string res = String.Format("Обслужено клиентов: {0:D} | ", this.served_n);
		res += String.Format("Отказов: {0:D} | ", this.refused_n);
		res += String.Format("Вероятность отказа: {0:F4} | ", Math.Round((double)refused_n / (refused_n + served_n), 4));
		res += String.Format("Время моделирования: {0:F4} [мин] ", this.end_time);
		return res;
	}
	
	private void reset(int _max_clients_n = 300)
	{
		clients.gen_time = 0;
		for (int i = 0; i < operators.Count; i++)
			operators[i].free_time = 0;
		for (int i = 0; i < storages.Count; i++)
			storages[i].max_size = 0;
		for (int i = 0; i < computers.Count; i++)
			computers[i].free_time = 0;
		max_clients_n = _max_clients_n;
		end_time = 0;
		refused_n = 0;
		served_n = 0;
		clients_n = 0;
		Request first_client = clients.genRequest();
		events = new List<BaseEvent> { new EClientCame(first_client) };
	}
	public Generator clients;
	public List<Service> operators;
	public List<ReqQue> storages;
	public List<Service> computers;
	public int max_clients_n = 300;
	public double end_time = 0;
	public int refused_n = 0;
	public int served_n = 0;
	public int clients_n = 0;
	private List<BaseEvent> events = new List<BaseEvent>();
}
