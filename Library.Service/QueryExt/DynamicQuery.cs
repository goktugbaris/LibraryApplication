using AutoMapper;
using Library.Core.DTOs.PostDTOs;
using System.Linq.Dynamic.Core;

namespace Library.Service.QueryExt
{
    public static class DynamicQuery
    {
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }
        public static string GetFilter(string filter2)
        {
            while (filter2.Contains("~"))
            {
                var index1 = filter2.IndexOf("~");
                var index2 = filter2.IndexOf("\"", index1 + 1);
                var index3 = filter2.IndexOf("\"", index2 + 1);

                var text1 = filter2.Substring(0, index1);
                var keyword = text1;
                if (keyword.Contains("AND") || keyword.Contains("OR"))
                {
                    var index11 = keyword.LastIndexOf(" ");
                    if (index11 > 0)
                    {
                        keyword = keyword.Substring(index11, keyword.Length - index11);
                        text1 = text1.Substring(0, index11);
                    }
                }
                else
                {
                    text1 = "";
                }

                var text2 = filter2.Substring(index2 + 1, index3 - index2 - 1);
                var value = text2;

                var command = keyword + ".ToLower().CONTAINS(\"" + value.ToLower() + "\")";

                if (value.Contains("ı"))
                    command += " OR " + keyword + ".ToLower().CONTAINS(\"" + value.Replace("ı", "i").ToLower() + "\")";

                if (value.Contains("I"))
                    command += " OR " + keyword + ".ToLower().CONTAINS(\"" + value.Replace("I", "İ").ToLower() + "\")";

                var text3 = filter2.Substring(index3 + 1);

                filter2 = text1 + command + text3;
            }
            return filter2;
        }


        public static IQueryable<T> ToDynamicWhereAndOrder<T>(this IQueryable<T> query, ListPostModel p,
            string defaultField = "Name", string defaultDir = "ASC")
            where T : class
        {
            if (p.OrderDir == "ascend" || p.OrderDir == "ASCEND")
            {
                p.OrderDir = "ASC";
            }

            else if (p.OrderDir == "descend" || p.OrderDir == "DESCEND")
            {
                p.OrderDir = "DESC";
            }

            if (!p.Filter.IsEmpty())
                query = query.Where(p.Filter);

            if (!p.OrderDir.IsEmpty() && !p.OrderField.IsEmpty())
                query = query.OrderBy(p.OrderField + " " + p.OrderDir);
            else
                query = query.OrderBy(defaultField + " " + defaultDir);
            return query;
        }
        public static IQueryable<T> ToDynamicWhere<T>(this IQueryable<T> query, string filter)
    where T : class
        {
            if (!filter.IsEmpty())
            {
                query = query.Where(GetFilter(filter));
            }
            return query;
        }
        public static IQueryable<Z> QueryResultDto<T, Z>(this IQueryable<T> query, IMapper mapper)
         where T : class
         where Z : class
        {
            return mapper.ProjectTo<Z>(query, null);
        }
    }
}
