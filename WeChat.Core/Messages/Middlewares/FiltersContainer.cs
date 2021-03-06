﻿using System;
using System.Collections.Generic;

namespace WeChat.Core.Messages.Middlewares
{
    /// <summary>
    /// 过滤器容器
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class FiltersContainer<TRequest>
    {
        /// <summary>
        /// 过滤器
        /// </summary>
        private readonly List<Action<TRequest, MiddlewareParameter>> _filters;

        public FiltersContainer()
        {
            _filters = new List<Action<TRequest, MiddlewareParameter>>();
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            this._filters.RemoveAt(index);
        }

        /// <summary>
        /// 注入过滤器
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public FiltersContainer<TRequest> Inject(Action<TRequest, MiddlewareParameter> filter)
        {
            _filters.Add(filter);
            return this;
        }

        /// <summary>
        /// 执行过滤器
        /// </summary>
        /// <param name="req"></param>
        /// <param name="middleware"></param>
        public void Execute(TRequest req, MiddlewareParameter middleware)
        {
            this._filters.ForEach(filter => filter(req, middleware));
        }
    }

}
