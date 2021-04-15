using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Utility.Enums
{
    public enum RelationTypes : int
    {
        /// <summary>
        /// هیچکدام
        /// </summary>
        None = 0,
        PostPeople = 1,
        PostTags = 2,
        EventPost = 3,
        EventTags = 4,
        EventPeople = 5,
        PeopleTags = 6
    }
}
