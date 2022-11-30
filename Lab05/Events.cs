using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    abstract class BaseEvent : IComparable<BaseEvent>
    {
        public BaseEvent(double _time)
        {
            time = _time;
        }

        public int CompareTo(BaseEvent other)
        {
            if (this.time > other.time)
                return 1;
            else
                return -1;
        }
        abstract public void Handle(EventModel model);

        public double time;
    }

    class EClientCame : BaseEvent
    {
        public EClientCame(Request _client) : base(_client.create_time)
        {
            client = _client;
        }

        public override void Handle(EventModel model)
        {
            model.clients_n++;

            if (model.clients_n < model.max_clients_n)
            {
                Request next_client = model.clients.genRequest();
                model.addEvent(new EClientCame(next_client));
            }

            for (int i = 0; i < model.operators.Count; i++)
                if (model.operators[i].isFree(this.time))
                {
                    model.operators[i].serve(this.client, this.time);
                    Request client_req = new Request(this.client.serve_time);
                    model.addEvent(new EClientServed(client_req, i));

                    model.served_n++;
                    return;
                }

            model.refused_n++;
        }

        private Request client;
    }

    class EClientServed : BaseEvent
    {
        public EClientServed(Request _client_request, int _operator_id) : base(_client_request.create_time)
        {
            client_req = _client_request;
            operator_id = _operator_id;
        }

        public override void Handle(EventModel model)
        {
            int target_storage_id = (operator_id == 2) ? 1 : 0;
            model.storages[target_storage_id].push(client_req);
            if (model.computers[target_storage_id].isFree(this.time))
                model.addEvent(new EClientReqServed(this.time, target_storage_id));
                //model.addEvent(new EClientReqRecieved(this.time, target_storage_id));
        }

        private Request client_req;
        private int operator_id;
    }

    /*class EClientReqRecieved : BaseEvent
    {
        public EClientReqRecieved(double _time, int _storage_id) : base(_time)
        {
            storage_id = _storage_id;
        }

        public override void Handle(EventModel model)
        {
            if (model.storages[storage_id].Count != 0)
            {
                Request client_req = model.storages[storage_id].pop();
                model.computers[storage_id].serve(client_req, this.time);
                model.addEvent(new EClientReqServed(model.computers[storage_id].free_time, storage_id));
            }
        }

        private int storage_id;
    }*/

    class EClientReqServed : BaseEvent
    {
        public EClientReqServed(double _time, int _storage_id) : base(_time)
        {
            id = _storage_id;
        }

        public override void Handle(EventModel model)
        {
            if (model.storages[id].Count != 0)
            {
                Request client_req = model.storages[id].pop();
                model.computers[id].serve(client_req, this.time);
                model.addEvent(new EClientReqServed(model.computers[id].free_time, id));
            }
        }

        private int id;
    }
}
