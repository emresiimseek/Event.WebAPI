using Event.Core.Concrete;
using Event.Core.Helpers;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccsess.Concrete
{
    public class CategoryDal : RepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(EventContext context, IApplicationUser applicationUser) : base(context, applicationUser)
        {

        }
    }
}
