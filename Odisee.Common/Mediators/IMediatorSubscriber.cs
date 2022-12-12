using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odisee.Common.Mediators
{
    public interface IMediatorSubscriber
    {
        void MediatorNotification(Object from, String message, Object data);
    }
}
