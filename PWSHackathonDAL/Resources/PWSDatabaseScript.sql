USE [PWS_Database]
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

DELETE FROM Risks
GO
DELETE FROM RiskAssessments
GO
DELETE FROM Questions
GO

INSERT [dbo].[Questions] ([ID], [Description], [IsHazard], [Severity], [RiskNumber]) VALUES (1, N'Question 1', 1, 3, N'A1')
GO
INSERT [dbo].[Questions] ([ID], [Description], [IsHazard], [Severity], [RiskNumber]) VALUES (2, N'Question 2', 0, 4, N'A2')
GO
INSERT [dbo].[Questions] ([ID], [Description], [IsHazard], [Severity], [RiskNumber]) VALUES (3, N'Question 3', 1, 5, N'A3')
GO
INSERT [dbo].[Questions] ([ID], [Description], [IsHazard], [Severity], [RiskNumber]) VALUES (4, N'Question 4', 0, 4, N'B1')
GO
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
