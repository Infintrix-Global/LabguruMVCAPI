using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabGuru.WebAPI.Models
{
    public class ResponceMessages
    {
        public bool isSuccess{ get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResponceMessages Failed(string Message)
        {
            this.isSuccess = false;
            this.Message = Message;
            this.Data = null;
            return this;
        }
        public ResponceMessages Failed(string Message, object data )
        {
            this.isSuccess = false;
            this.Message = Message;
            this.Data = data;
            return this;
        }

        public ResponceMessages Success(string Message)
        {
            this.isSuccess = true;
            this.Message = Message;
            this.Data = null;
            return this;
        }
        public ResponceMessages Success(string Message, object data)
        {
            this.isSuccess = true;
            this.Message = Message;
            this.Data = data;
            return this;
        }
    }
}
