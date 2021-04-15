using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Utility.Enums
{

    /// <summary>
    /// انواع روابط در جدول اعضا
    /// </summary>
    public enum OperationTypes : byte
    {
        /// <summary>
        /// نیازمند ثبت تاریخچه
        /// </summary>
        Historical = 1,
        /// <summary>
        /// بدون نیاز به ثبت تاریخچه
        /// </summary>
        NonHistorical = 2
    }

    /// <summary>
    /// کاردینالیتی روابط در جدول اعضا
    /// </summary>
    public enum Cardinalities : byte
    {
        /// <summary>
        /// یک به یک
        /// </summary>
        Peer2Peer = 1,
        /// <summary>
        /// یک به چند
        /// </summary>
        One2Many = 2,
        /// <summary>
        /// چند به چند
        /// </summary>
        Many2Many = 3
    }

    public enum CenterTypes
    {
        Specials = 1,
        Posts = 2,
        People = 3,
        Tags = 4,
    }

    public enum ConversionStatus
    {
        InQueue = 0,
        Processing = 1,
        Done = 2,
        Failed = 3
    }
}
