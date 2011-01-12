﻿#region Copyright and license information
// Copyright 2010-2011 Jon Skeet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
using System;
using System.Collections;
using System.Collections.Generic;

namespace Edulinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> OfType<TResult>(this IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            IEnumerable<TResult> existingSequence = source as IEnumerable<TResult>;
            if (existingSequence != null && default(TResult) != null)
            {
                return existingSequence;
            }
            return OfTypeImpl<TResult>(source);
        }

        private static IEnumerable<TResult> OfTypeImpl<TResult>(IEnumerable source)
        {
            foreach (object item in source)
            {
                if (item is TResult)
                {
                    yield return (TResult) item;
                }
            }
        }
    }
}
