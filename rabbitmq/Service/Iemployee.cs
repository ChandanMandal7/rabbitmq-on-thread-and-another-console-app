using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rabbitmq.Service
{
    public interface Iemployee
    {
        public void PostEmploye<T>(T EmplyeeModel);
    }
}