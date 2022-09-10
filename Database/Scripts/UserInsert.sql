INSERT INTO Users
           (AccessFailedCount,Email,EmailConfirmed,LockoutEnabled,LockoutEnd,NormalizedEmail,NormalizedUserName
		   ,PasswordHash,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,UserName, CompanyId, BranchId)
     VALUES
           (0, 'super@admin.com',1,	0,	NULL, 'SUPER@ADMIN.COM', 'SUPER@ADMIN.COM', 
		   'AQAAAAEAACcQAAAAEIOoNfljYDmpM3h/S+GBw8J7PrCzQ0LZmfqlYvpLHk+uxhyVxhUKbI7DvC039O3oIg==',	NULL,0, 0,	'super@admin.com',
           1, 1)