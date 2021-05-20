﻿/* 
 * Copyright (c) 2020, Norsk Helsenett SF and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the MIT license
 * available at https://raw.githubusercontent.com/helsenorge/Helsenorge.Messaging/master/LICENSE
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Helsenorge.Messaging.Abstractions;

namespace Helsenorge.Messaging.Tests.Mocks
{
    internal class MockSender : IMessagingSender
    {
        private readonly MockFactory _factory;
        private readonly string _id;
        
        public MockSender(MockFactory factory, string id)
        {
            _factory = factory;
            _id = id;
        }

        public bool IsClosed => false;
        public Task Close() { return Task.CompletedTask; }

        public Task SendAsync(IMessagingMessage message)
        {
            List<IMessagingMessage> queue;
            if (_factory.Qeueues.ContainsKey(_id) == false)
            {
                queue = new List<IMessagingMessage>();
                _factory.Qeueues.Add(_id, queue);
            }
            else
            {
                queue = _factory.Qeueues[_id];
            }
            
            var m = message as MockMessage;
            m.Queue = queue;
            
            //validate To queue so we can test errors connecting to queues. Different implementations throw different exceptions
            if (!string.IsNullOrEmpty(message.To) && message.To.StartsWith("Dialog_"))
            {
                throw new MessagingException();
            }

            queue.Add(message);
            return Task.CompletedTask;
        }
    }
}
