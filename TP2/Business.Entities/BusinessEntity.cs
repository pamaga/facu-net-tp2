using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private States _State;
        private int _Id;

        public BusinessEntity()
        {
            this.State = States.New;
        }
       
        public States State {
            get { return _State; }
            set { this._State = value;}
        }
        public int Id
        {
            get { return _Id; }
            set { this._Id = value; }
        }

        
        public enum States { 
            Deleted,
            New,
            Modified,
            Unmodified
        }
    }
}
