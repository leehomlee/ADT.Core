using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;

namespace ADT.Core.Mvc.TagHelpers.Custom.TagHelpers
{
    [HtmlTargetElement("movie", TagStructure = TagStructure.WithoutEndTag)]
    public class MovieTagHelper : TagHelper
    {
        [HtmlAttributeName("for-title")]
        public ModelExpression Title { get; set; }
        [HtmlAttributeName("for-year")]
        public ModelExpression ReleaseYear { get; set; }
        [HtmlAttributeName("for-director")]
        public ModelExpression Director { get; set; }
        [HtmlAttributeName("for-summary")]
        public ModelExpression Summary { get; set; }
        [HtmlAttributeName("for-stars")]
        public ModelExpression Stars { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!(this.Stars.Model is List<string>))
                throw new ArgumentException("Stars must bu a list");

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "movie-tag");

            output.Content.AppendHtml(GetTitle());
            output.Content.AppendHtml(GetDirector());
            output.Content.AppendHtml(GetSummary());
            output.Content.AppendHtml(GetStars());
        }

        private TagBuilder GetTitle()
        {
            var year = new TagBuilder("span");
            year.Attributes.Add("class", "movie-year");
            year.InnerHtml.AppendHtml($"({this.ReleaseYear.Model})");

            var title = new TagBuilder("div");
            title.Attributes.Add("class", "movie-title");
            title.InnerHtml.AppendHtml($"{this.Title.Model}");
            title.InnerHtml.AppendHtml(year);

            return title;
        }

        private TagBuilder GetDirector()
        {
            var director = new TagBuilder("div");
            director.Attributes.Add("class", "movie-director");
            director.InnerHtml.AppendHtml($"<span>Director: {this.Director.Model}</span>");
            return director;
        }

        private TagBuilder GetSummary()
        {
            var summary = new TagBuilder("div");
            summary.Attributes.Add("class", "movie-summary");
            summary.InnerHtml.AppendHtml($"<span><strong>Plot: </strong>{this.Summary.Model}</span>");
            return summary;
        }

        private TagBuilder GetStars()
        {
            var stars = new TagBuilder("div");
            stars.Attributes.Add("class", "movie-stars");
            stars.InnerHtml.AppendHtml("<strong>Stars</strong>");
            stars.InnerHtml.AppendHtml("<ul>");

            var model = this.Stars.Model as List<string>;
            foreach (var star in model)
            {
                stars.InnerHtml.AppendHtml($"<li>{star}</li>");
            }

            stars.InnerHtml.AppendHtml("</ul>");
            return stars;
        }
    }
}
