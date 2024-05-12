cd ..
cd ..
dotnet ef dbcontext scaffold "Server=localhost;Database=master;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir "DB\Models" --context-dir "DB\Context" --context "MarketContext"
pause