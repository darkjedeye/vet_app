
INSERT [dbo].[Applications] ([ApplicationId], [ApplicationName], [Description]) 
	VALUES (N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'HuskyRescue', NULL)

INSERT [dbo].[Users] ([UserId], [ApplicationId], [UserName], [IsAnonymous], [LastActivityDate]) 
	VALUES (N'076982f1-8abc-4dcb-9ca7-5bd114aa522b', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'admin', 0, CAST(0x0000A1EA0072116B AS DateTime))
INSERT [dbo].[Users] ([UserId], [ApplicationId], [UserName], [IsAnonymous], [LastActivityDate]) 
	VALUES (N'2e3b60ba-13fd-432d-b62a-8bed073ac337', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'bizuser', 0, CAST(0x0000A1EA0071F24C AS DateTime))

INSERT [dbo].[Memberships] ([UserId], [ApplicationId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) 
	VALUES (N'076982f1-8abc-4dcb-9ca7-5bd114aa522b', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'b6lp0HDSExzlfXNRYVwnFYJnFrg8SP3hmf/7MES0fC4=', 1, N'47ZGm2HqVQgKENAdJVWxbg==', N'me@info.com', N'Favorite Color', N'14519rvsPsV/pGkKKXBp7tmVl2b/jy2K2XkUBeG8tt8=', 1, 0, CAST(0x0000A1EA0071F1F4 AS DateTime), CAST(0x0000A1EA0072116B AS DateTime), CAST(0x0000A1EA0071F1F4 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)
INSERT [dbo].[Memberships] ([UserId], [ApplicationId], [Password], [PasswordFormat], [PasswordSalt], [Email], [PasswordQuestion], [PasswordAnswer], [IsApproved], [IsLockedOut], [CreateDate], [LastLoginDate], [LastPasswordChangedDate], [LastLockoutDate], [FailedPasswordAttemptCount], [FailedPasswordAttemptWindowStart], [FailedPasswordAnswerAttemptCount], [FailedPasswordAnswerAttemptWindowsStart], [Comment]) 
	VALUES (N'2e3b60ba-13fd-432d-b62a-8bed073ac337', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'AxD8PQKJPIDyq3s0CaGCED+Qdlsc5gvsgPPT3yUMFA0=', 1, N'pESkDkSaGVVivzJAcsCArg==', N'ninjaburp@aol.com', N'Favorite Movie', N'chD0PjEpw6zUmLlOIz+F5JP7VmmoXtkeDqG2rFaXqDE=', 1, 0, CAST(0x0000A1EA0071F242 AS DateTime), CAST(0x0000A1EA0071F242 AS DateTime), CAST(0x0000A1EA0071F242 AS DateTime), CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), 0, CAST(0xFFFF2FB300000000 AS DateTime), NULL)

INSERT [dbo].[Roles] ([RoleId], [ApplicationId], [RoleName], [Description]) 
	VALUES (N'7d07d87a-39b2-46ab-b3e5-2ea0ff6f9724', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'Manager', NULL)
INSERT [dbo].[Roles] ([RoleId], [ApplicationId], [RoleName], [Description]) 
	VALUES (N'd5e25f5d-a446-42b2-ba60-62403219bbf6', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'Administrator', NULL)
INSERT [dbo].[Roles] ([RoleId], [ApplicationId], [RoleName], [Description]) 
	VALUES (N'a5c6f1db-f517-4363-b022-a5326fb46fcc', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'SecurityGuard', NULL)
INSERT [dbo].[Roles] ([RoleId], [ApplicationId], [RoleName], [Description]) 
	VALUES (N'6F6FF7EA-FC71-467A-807C-459A0C6B0F30', N'11ab102f-f595-4d4d-940d-9cccc77ec72b', N'Staff', NULL)
	
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'076982f1-8abc-4dcb-9ca7-5bd114aa522b', N'd5e25f5d-a446-42b2-ba60-62403219bbf6')
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'076982f1-8abc-4dcb-9ca7-5bd114aa522b', N'a5c6f1db-f517-4363-b022-a5326fb46fcc')
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'076982f1-8abc-4dcb-9ca7-5bd114aa522b', N'6F6FF7EA-FC71-467A-807C-459A0C6B0F30')
INSERT [dbo].[UsersInRoles] ([UserId], [RoleId]) VALUES (N'2e3b60ba-13fd-432d-b62a-8bed073ac337', N'd5e25f5d-a446-42b2-ba60-62403219bbf6')

GO