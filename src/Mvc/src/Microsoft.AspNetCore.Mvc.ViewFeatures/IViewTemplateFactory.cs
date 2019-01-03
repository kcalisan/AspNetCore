// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc.ViewFeatures
{
    public interface IViewTemplateFactory
    {
        ValueTask<LocateViewResult> LocateViewAsync(ViewFactoryContext context);
    }

    public readonly struct LocateViewResult
    {
        public LocateViewResult(IViewTemplatingSystem viewTemplate)
        {
            ViewTemplate = viewTemplate ?? throw new ArgumentNullException(nameof(viewTemplate));
            SearchedLocations = null;
        }

        public LocateViewResult(IEnumerable<string> searchedLocations)
        {
            ViewTemplate = null;
            SearchedLocations = searchedLocations ?? throw new ArgumentNullException(nameof(searchedLocations));
        }

        public IViewTemplatingSystem ViewTemplate { get; }

        public IEnumerable<string> SearchedLocations { get; }

        public bool Success => ViewTemplate != null;
    }
}
