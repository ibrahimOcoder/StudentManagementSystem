using StudentManagementSystem.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Integrations.MessagingBus
{
    public interface IMessageBus
    {
        Task PublishMessage(IntegrationBaseMessage message, string exchangeName);
    }
}
