USE [gameshop]
GO

/****** Object:  Table [dbo].[Items]    Script Date: 11.06.2017 16:35:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Items](
	[item_id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[price] [money] NOT NULL,
	[tax_rate] [float] NOT NULL,
	[unit] [nvarchar](20) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[available_quantity] [int] NOT NULL,
	[description] [nvarchar](2000) NOT NULL,
	[loyality_points] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

