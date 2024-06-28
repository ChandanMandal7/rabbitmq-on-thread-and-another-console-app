using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmq.models
{
    public class EmplyeeModel
    {
        public int Id{get;set;}
        public string  name {get;set;}
        public string  email {get;set;}
        public long phoneNumber {get;set;}
    }
}