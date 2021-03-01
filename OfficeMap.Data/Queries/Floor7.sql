--Pievieno darbiniekus---
INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('ricards.maurins@if.lv', 'Valdnieks', N'Ričards', '29183049', N'Mauriņš', 'it', 'EUROPE\MAURIKS', 1)
DECLARE @employee1Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id,  user_identity, is_super_user) VALUES
	('nikita.dzervans@if.lv', N'Programmētājs', N'Ņikita', '22832269', N'Dzērvāns', 'it', 'EUROPE\DZENIKS', 1)
DECLARE @employee2Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('egils.dunkurs@if.lv', N'Programmētājs', N'Egīls', '20000000', N'Dunkurs', 'it', 'EUROPE\DUNEGIS', 1)
DECLARE @employee3Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('rozine@gmail.com', 'Masiere', N'Efrozīne', '20000001', N'Lielpēde', 'hr', 'EUROPE\LIEEFRS', 0)
DECLARE @employee4Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('maris.lazdins@if.lv', 'BOSS', N'Māris', '20000001', N'Lazdiņš', 'it', 'EUROPE\LAZMARS', 1)
DECLARE @employee5Id INT = @@IDENTITY

	---Pievieno 7. stāvu---
INSERT dbo.Floors (seq, title, width, height) VALUES
	(7, N'7. stāvs', 800, 1700)

DECLARE @floorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1425, 800, null, @floorId, 'wall', null, null, null, 0, 126) 

DECLARE @wholeFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(0, 800, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 0) 

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1425, 1, null, @floorId, 'wall', null, null, null, 0, 126) 

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1425, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 801, 0)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1, 799, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 1425)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(65, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 0)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(65, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 0)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1010, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 110)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1010, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 110)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(260, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 1165)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(260, 0, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1165)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(1, 250, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 1165)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(0, 250, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 213)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	--Lielais kvadrats---
	(0, 250, null, @floorId, 'wall', @wholeFloorId, null, null, 275, 915)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(200, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 0, 0)

DECLARE @firstSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(65, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 163, 0)

DECLARE @secondSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(55, 112, null, @floorId, 'wc', @wholeFloorId, null, null, 163, 145) 

DECLARE @thirdSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(100, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 200) 

DECLARE @fourthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(80, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 300) 

DECLARE @fifthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(100, 112, null, @floorId, 'kitchen', @wholeFloorId, null, null, 163, 200) 

DECLARE @sixthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(80, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 500) 

DECLARE @seventhSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(180, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 580) 

DECLARE @eightSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(80, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 760) 

DECLARE @ninthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(80, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 163, 500) 

DECLARE @tenthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(285, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 163, 580) 

DECLARE @eleventhSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(100, 113, null, @floorId, 'kitchen', @wholeFloorId, null, null, 162, 925)

DECLARE @twelfthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(95, 113, null, @floorId, 'wc', @wholeFloorId, null, null, 162, 1025)

DECLARE @thirteenthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 113, null, @floorId, 'colorWall', @wholeFloorId, null, null, 162, 1165)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(95, 113, null, @floorId, 'meeting', @wholeFloorId, null, null, 0, 1025)

DECLARE @fourteenthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 113, null, @floorId, 'wardrobe', @wholeFloorId, null, null, 0, 1120)

DECLARE @fifteenthSquareInLeftFloorId INT = @@IDENTITY


INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(65, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 525, 0)

DECLARE @firstSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(55, 112, null, @floorId, 'wc', @wholeFloorId, null, null, 525, 145) 

DECLARE @secondSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(200, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 688, 0)

DECLARE @thirdSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(100, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 200) 

DECLARE @fourthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(80, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 300) 

DECLARE @fifthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(225, 112, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 700) 

DECLARE @sixthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(100, 113, null, @floorId, 'kitchen', @wholeFloorId, null, null, 525, 925)

DECLARE @seventhSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(95, 113, null, @floorId, 'wc', @wholeFloorId, null, null, 525, 1025)

DECLARE @eightSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 113, null, @floorId, 'colorWall', @wholeFloorId, null, null, 525, 1165)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(100, 113, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1195)

DECLARE @ninthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(70, 113, null, @floorId, 'wall', @wholeFloorId, null, null, 687, 730)

DECLARE @tenthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(1, 113, null, @floorId, 'wall', @wholeFloorId, null, null, 687, 890)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 113, null, @floorId, 'wardrobe', @wholeFloorId, null, null, 687, 1025)

DECLARE @eleventhSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(60, 113, null, @floorId, 'wall', @wholeFloorId, null, null, 687, 1125)

DECLARE @twelvethSquareInRightFloorId INT = @@IDENTITY


INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@firstSquareInLeftFloorId, N'Kuldīga', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@secondSquareInLeftFloorId, N'Tērvete', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareInLeftFloorId, 'WC', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@sixthSquareInLeftFloorId, 'Virtuve', 'title')

			---Pievieno liftus---
INSERT dbo.Objects (floor_id, object_type_id, parent_object_id, svg_type_id, top_left_x, top_left_y) VALUES
	(@floorId, 'lift', @wholeFloorId, 'lift', 345, 1015)

INSERT dbo.Objects (floor_id, object_type_id, parent_object_id, svg_type_id, top_left_x, top_left_y) VALUES
	(@floorId, 'lift', null, 'lift2', 276, 0)

		---Pievieno kāpnes---
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'stairs', @wholeFloorId, null, 'stairs', 285, 110)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'stairs', @wholeFloorId, null, 'stairs', 285, 917)