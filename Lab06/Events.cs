using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
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

    class EStudentCame : BaseEvent
    {
        public EStudentCame(Request _student) : base(_student.create_time)
        {
            student = _student;
        }

        public override void Handle(EventModel model)
        {
            model.students_n++;

            if (model.students_n < model.max_students_n)
            {
                Request next_student = model.students.genRequest();
                model.addEvent(new EStudentCame(next_student));
            }

            model.normcontrol_que.push(student);
            if (model.normcontrol.isFree(this.time))
                model.addEvent(new EStudentNormcontrolPass(this.time));
        }

        private Request student;
    }

    class EStudentNormcontrolPass : BaseEvent
    {
        public EStudentNormcontrolPass(double _time) : base(_time) {}

        public override void Handle(EventModel model)
        {
            if (model.normcontrol_que.Count != 0)
            {
                Request student = model.normcontrol_que.pop();
                bool pass = model.normcontrol.serve(student, this.time);
                if (!pass)
                {
                    model.normcontrol_que.push(student);
                    model.addEvent(new EStudentNormcontrolPass(model.normcontrol.free_time));
                }
                else
				{
                    Request student_rdy = new Request(student.serve_time);
                    model.protection_que.push(student_rdy);
                    if (model.comissions[0].isFree(student_rdy.create_time) || model.comissions[1].isFree(student_rdy.create_time))
                        model.addEvent(new EStudentProtection(student_rdy.create_time));
                }
                model.addEvent(new EStudentNormcontrolPass(model.normcontrol.free_time));
            }
        }
    }

    class EStudentProtection : BaseEvent
    {
        public EStudentProtection(double _time) : base(_time) {}

        public override void Handle(EventModel model)
        {
            if (model.protection_que.Count != 0)
            {
                for (int i = 0; i < model.comissions.Count; i++)
                {
                    if (model.comissions[i].isFree(this.time))
                    {
                        Request student_rdy = model.protection_que.pop();
                        bool pass = model.comissions[i].serve(student_rdy, this.time);
                        if (!pass)
                            model.refused_n++;
                        else
                            model.passed_n++;

                        model.addEvent(new EStudentProtection(model.comissions[i].free_time));
                        break;
                    }
                }
            }
        }
    }
}
