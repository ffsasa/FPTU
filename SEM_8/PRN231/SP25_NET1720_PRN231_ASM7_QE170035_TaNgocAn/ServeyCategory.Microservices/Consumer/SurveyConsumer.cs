using BusinessObject.Shared.Models;
using Common.Shared;
using MassTransit;

namespace ServeyCategory.Microservices.Consumer
{
    public class SurveyConsumer : IConsumer<Survey>
    {
        private readonly ILogger _logger;

        public SurveyConsumer(ILogger<SurveyConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<Survey> context)
        {
            //https://localhost:7199/gateway/order

            #region Receive data from Queue on RabbitMQ            

            var data = context.Message;

            #endregion

            #region Business rule process anh/or call other API Service

            //Validate the Data
            //Store to Database
            //Notify the user via Email / SMS

            #endregion

            #region Logger

            if (data != null)
            {
                string messageLog = string.Format("[{0}] RECEIVE data from RabbitMQ.surveyQueue: {1}", DateTime.Now.ToString(), JsonUtils.ConvertObjectToJSONString(data));

                JsonUtils.WriteLoggerFile(messageLog);

                _logger.LogInformation(messageLog);

            }

            #endregion

        }
    }
}
