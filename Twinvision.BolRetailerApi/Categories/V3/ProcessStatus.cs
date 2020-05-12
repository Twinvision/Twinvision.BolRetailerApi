using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Twinvision.BolRetailerApi
{
    public enum ProcessEventType { CONFIRM_SHIPMENT, CANCEL_ORDER, CHANGE_TRANSPORT, HANDLE_RETURN_ITEM, CREATE_RETURN_ITEM, CREATE_INBOUND, DELETE_OFFER, CREATE_OFFER, UPDATE_OFFER, UPDATE_OFFER_STOCK, UPDATE_OFFER_PRICE, CREATE_OFFER_EXPORT, CREATE_PRODUCT_CONTENT };
    public class ProcessStatuses : BolApiHttpRequestHandler
    {
        private BolApiCaller BolApiCaller;
        public ProcessStatuses(BolApiCaller bolApiCaller)
        {
            BolApiCaller = bolApiCaller;
        }

        /// <summary>
        /// Retrieve a list of process statuses, which shows information regarding previously executed PUT/POST requests in descending order. 
        /// You need to supply an entity id and event type.
        /// </summary>
        /// <param name="entityId">The entity id is not unique so you need to provide an event type. The entity id can either be order item id, transport id, return number or inbound reference.</param>
        /// <param name="eventType">The event type can only be used in combination with the entity id.</param>
        /// <param name="page">The requested page number with a pagesize of 50</param>
        /// <returns></returns>
        public async Task<ProcessStatusesContainer> GetProcessStatusByEntityAndEvent(string entityId, ProcessEventType eventType, int page = 1)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "entity-id", entityId },
                { "event-type", eventType.ToString() },
                { "page", page.ToString() }
            };
            var response = await Get("/process-status", queryParameters);
            return await BolApiHelper.GetContentFromResponse<ProcessStatusesContainer>(response);
        }

        /// <summary>
        /// Retrieve a specific process-status, which shows information regarding a previously executed PUT/POST request. 
        /// All PUT/POST requests on the other endpoints will supply a process-status-id in the related response. 
        /// You can use this id to retrieve a status by using the endpoint below.
        /// </summary>
        /// <param name="processStatusId">The id of the process status being requested. This id is supplied in every response to a PUT/POST request on the other endpoints.</param>
        /// <returns></returns>
        public async Task<ProcessStatus> GetStatusByProcessId(string processStatusId)
        {
            var response = await Get("/process-status/" + processStatusId.ToString());
            return await BolApiHelper.GetContentFromResponse<ProcessStatus>(response);
        }

        /// <summary>
        /// Retrieve a list of process statuses, which shows information regarding previously executed PUT/POST/DELETE requests. 
        /// No more than 1000 process status id's can be sent in a single request.
        /// </summary>
        /// <param name="processStatusIds">Array of objects (ProcessStatusId)</param>
        /// <returns></returns>
        public async Task<ProcessStatusesContainer> GetProcessStatusesByIds(string[] processStatusIds)
        {
            var processStatusQueries = new ProcessStatusQuery[processStatusIds.Length];
            for (int i = 0; i < processStatusIds.Length; i++)
            {
                processStatusQueries[i] = new ProcessStatusQuery() { Id = processStatusIds[i] };
            }
            var newObject = new
            {
                processStatusQueries = processStatusQueries
            };
            using (var content = BolApiHelper.BuildContentFromObject(newObject))
            {
                var response = await Post("/process-status", content);
                return await BolApiHelper.GetContentFromResponse<ProcessStatusesContainer>(response);
            }
        }
    }
}
