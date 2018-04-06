﻿using System;
using System.Collections.Generic;
using ADT.Core.Api.Paging.Lib;

namespace ADT.Core.Api.Paging.Models.Movies
{
    public class MovieOutputModel
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<MovieInfo> Items { get; set; }
    }

    public class MovieInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Summary { get; set; }
        public DateTime LastReadAt { get; set; }
    }
}
