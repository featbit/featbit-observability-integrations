using Newtonsoft.Json;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace GuanceSDK.Utils
{
    public class DataKitSender
    {
        /// <summary>
        /// 会话id（后台停留30s以上，会生成一个新的session_id
        /// </summary>
        [JsonProperty("session_id")]
        public string? SessionId { get; set; }

        /// <summary>
        /// 会话类型。参考值：user & test user表示是RUM功能产生的数据；test表示是headless拨测产生的数据。
        /// </summary>
        [JsonProperty("session_type")]
        public string? SessionType { get; set; }

        /// <summary>
        /// 会话来源。一般是记录来源的页面地址。
        /// </summary>
        [JsonProperty("session_referrer")]
        public string? SessionReferrer { get; set; }

        /// <summary>
        /// 当前会话的第一个页面的view_id
        /// </summary>
        [JsonProperty("session_first_view_id")]
        public string? SessionFirstViewId { get; set; }

        /// <summary>
        /// 当前会话的第一个页面的URL
        /// </summary>
        [JsonProperty("session_first_view_name")]
        public string? SessionFirstViewName { get; set; }

        /// <summary>
        /// 当前会话的最后一个访问页面的view_id
        /// </summary>
        [JsonProperty("session_last_view_id")]
        public string? SessionLastViewId { get; set; }

        /// <summary>
        /// 当前会话的最后一个页面的URL
        /// </summary>
        [JsonProperty("session_referrer")]
        public string? SessionLastViewName { get; set; }
    }
}
