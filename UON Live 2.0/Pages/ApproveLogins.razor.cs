using Microsoft.AspNetCore.Identity;

private List<ApplicationUser> Users { get; set; }

protected override async Task OnInitializedAsync()
{
    Users = await UserManager.Users.ToListAsync();
}

private async Task Approve(string userId)
{
    var user = await UserManager.FindByIdAsync(userId);
    user.EmailConfirmed = true;
    await UserManager.UpdateAsync(user);
    Users = await UserManager.Users.ToListAsync();
}