using Domain.Entities;

namespace Domain.DTOs
{
    public class ExpanseMonthSummaryDto
    {
        public ExpanseMonthSummaryDto(List<Expanse> expanses, List<CategorySpend> totalSpendByCategories, double totalSpend)
        {
            Expanses = expanses;
            TotalSpendByCategories = totalSpendByCategories;
            TotalSpend = totalSpend;
        }

        public List<Expanse> Expanses { get; set; }
        public List<CategorySpend> TotalSpendByCategories { get; set; }
        public double TotalSpend { get; set; }
    }

    public class CategorySpend
    {
        public CategorySpend(string categoryName, double totalSpend)
        {
            CategoryName = categoryName;
            TotalSpend = totalSpend;
        }

        public string CategoryName { get; set; }
        public double TotalSpend { get; set; }


    }
}
