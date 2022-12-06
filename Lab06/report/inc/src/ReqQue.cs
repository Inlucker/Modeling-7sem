class ReqQue : Queue<Request>
{
	public bool push(Request r)
	{
		Enqueue(r);
		if (Count > max_size)
		{
			max_size = Count;
			return true;
		}
		return false;
	}
	public Request pop()
	{
		return Dequeue();
	}

	public int max_size = 0;
}
