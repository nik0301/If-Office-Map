
	---Pievieno darbiniekus---
INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('ricards.maurins@if.lv', 'Valdnieks', N'Ričards', '29183049', N'Mauriņš', 'it', 'EUROPE\MAURIC', 1)
DECLARE @employee1Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id,  user_identity, is_super_user) VALUES
	('nikita.dzervans@if.lv', N'Programmētājs', N'Ņikita', '22832269', N'Dzērvāns', 'it', 'EUROPE\DZENIK', 1)
DECLARE @employee2Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('egils.dunkurs@if.lv', N'Programmētājs', N'Egīls', '20000000', N'Dunkurs', 'it', 'EUROPE\DUNEGI', 1)
DECLARE @employee3Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('rozine@gmail.com', 'Masiere', N'Efrozīne', '20000001', N'Lielpēde', 'hr', 'EUROPE\LIEEFR', 0)
DECLARE @employee4Id INT = @@IDENTITY

INSERT dbo.Employees (email, job_title, name, phone, surname, unit_id, user_identity, is_super_user) VALUES
	('maris.lazdins@if.lv', 'BOSS', N'Māris', '20000001', N'Lazdiņš', 'it', 'EUROPE\LAZMAR', 1)
DECLARE @employee5Id INT = @@IDENTITY

	---Pievieno 6. stāvu---
INSERT dbo.Floors (seq, title, width, height) VALUES
	(6, N'6. stāvs', 800, 1700)

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
	(115, 100, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 0)

DECLARE @firstSquareInFirstSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(85, 100, null, @floorId, 'meeting', @wholeFloorId, null, null, 0, 115)

DECLARE @secondSquareInsidefirstSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(55, 125, null, @floorId, 'wc', @wholeFloorId, null, null, 150, 145) 

DECLARE @thirdSquareInsidefirstSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(125, 100, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 200)

DECLARE @firstSquareinSecondSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(100, 100, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 325)

DECLARE @secondSquareinSecondSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(150, 125, null, @floorId, 'kitchen', @wholeFloorId, null, null, 150, 200)

DECLARE @thirdSquareinSecondSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(75, 125, null, @floorId, 'wardrobe', @wholeFloorId, null, null, 150, 350)

	DECLARE @fourthSquareinSecondSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(1, 100, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 550)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(1, 125, null, @floorId, 'wall', @wholeFloorId, null, null, 150, 550)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(24, 24, null, @floorId, 'colorWall', @wholeFloorId, null, null, 175, 555)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(1, 125, null, @floorId, 'wall', @wholeFloorId, null, null, 150, 815)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(100, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 0, 925)

DECLARE @fourthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(100, 113, null, @floorId, 'kitchen', @wholeFloorId, null, null, 162, 925)

DECLARE @fifthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(125, 112, null, @floorId, 'meeting', @wholeFloorId, null, null, 0, 1025)

DECLARE @sixthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 112, null, @floorId, 'wardrobe', @wholeFloorId, null, null, 0, 1150)

DECLARE @seventhSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(95, 113, null, @floorId, 'wc', @wholeFloorId, null, null, 162, 1025)

DECLARE @eigthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(30, 113, null, @floorId, 'colorWall', @wholeFloorId, null, null, 162, 1165)

DECLARE @ninthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa Ieksejais kvadrats---
	(125, 145, null, @floorId, 'wall', @wholeFloorId, null, null, 0, 1300)

DECLARE @tenthSquareInLeftFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(24, 24, null, @floorId, 'colorWall', @wholeFloorId, null, null, 175, 1280)


INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(65, 90, null, @floorId, 'meeting', @wholeFloorId, null, null, 525, 0)

DECLARE @firstSquareInFirstSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(65, 30, null, @floorId, 'wardrobe', @wholeFloorId, null, null, 615, 0)

DECLARE @secondSquareInFirstSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(65, 100, null, @floorId, 'wc', @wholeFloorId, null, null, 525, 135)

DECLARE @thirdSquareInFirstSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(200, 125, null, @floorId, 'wall', @wholeFloorId, null, null, 675, 0)
	
DECLARE @fourthSquareInFirstSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(135, 100, null, @floorId, 'kitchen', @wholeFloorId, null, null, 525, 200)

DECLARE @firstSquareInSecondSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(90, 100, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 335)

DECLARE @secondSquareInSecondSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(135, 125, null, @floorId, 'wall', @wholeFloorId, null, null, 675, 200)

DECLARE @thirdSquareInSecondSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(90, 125, null, @floorId, 'wall', @wholeFloorId, null, null, 675, 335)

DECLARE @fourthSquareInSecondSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---1. korpusa siena---
	(24, 24, null, @floorId, 'colorWall', @wholeFloorId, null, null, 585, 585)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(100, 115, null, @floorId, 'kitchen', @wholeFloorId, null, null, 525, 925)

DECLARE @sixthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
		---2. korpusa Ieksejais kvadrats---
	(0, 275, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 700),
	
	---2. korpusa Ieksejais kvadrats---
	(100, 275, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1025)

DECLARE @fifthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	---Kvadrati iekseja kvadrata---
	(100, 115, null, @floorId, 'wc', @fifthSquareInRightFloorId, null, null, 0, 0)

DECLARE @squareInFifthSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
		---2. korpusa Ieksejais kvadrats---
	(1, 275, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1165),

		---2. korpusa Ieksejais kvadrats---
	(100, 145, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1275)

DECLARE @seventhSquareInRightFloorId INT = @@IDENTITY

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
		---2. korpusa Ieksejais kvadrats---
	(50, 145, null, @floorId, 'wall', @wholeFloorId, null, null, 525, 1375)

		---Pievieno objekta atribūtu---
INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareInsidefirstSquareInLeftFloorId, 'WC', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@eigthSquareInLeftFloorId, 'WC', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@squareInFifthSquareInRightFloorId, 'WC', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareInFirstSquareInRightFloorId, 'WC', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@secondSquareInsidefirstSquareInLeftFloorId, 'Vaidava', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareinSecondSquareInLeftFloorId, 'Virtuve', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareinSecondSquareInLeftFloorId, 'ir', 'fridge')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@thirdSquareinSecondSquareInLeftFloorId, 'ir', 'dishmach')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fourthSquareInLeftFloorId, 'Biksti', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fifthSquareInLeftFloorId, 'Virtuve', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fifthSquareInLeftFloorId, 'ir', 'fridge')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fifthSquareInLeftFloorId, 'ir', 'microwave')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fifthSquareInLeftFloorId, 'ir', 'dishmach')
	
INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@sixthSquareInLeftFloorId, 'Auri', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@firstSquareInFirstSquareInRightFloorId, N'Jūrmala', 'title')
	
INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@sixthSquareInRightFloorId, 'Virtuve', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@firstSquareInSecondSquareInRightFloorId, 'Virtuve', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@firstSquareInSecondSquareInRightFloorId, 'ir', 'fridge')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@firstSquareInSecondSquareInRightFloorId, 'ir', 'microwave')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@fourthSquareinSecondSquareInLeftFloorId, 'Garderobe', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@seventhSquareInLeftFloorId, 'Garderobe', 'title')

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@secondSquareInFirstSquareInRightFloorId, 'Garderobe', 'title')

	----------INSERT OBJECTS IN LEFT FLOOR PART-----------------

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee1Id, @floorId, 'workplace', @firstSquareInFirstSquareInLeftFloorId, null, 'workplace', 25, 60)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee2Id, @floorId, 'workplace', @firstSquareInFirstSquareInLeftFloorId, null, 'workplace', 50, 60)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee5Id, @floorId, 'workplace', @firstSquareInFirstSquareInLeftFloorId, 180, 'workplace', 25, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee3Id, @floorId, 'workplace', @firstSquareInFirstSquareInLeftFloorId, 180, 'workplace', 50, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee4Id, @floorId, 'workplace', @firstSquareinSecondSquareInLeftFloorId, null, 'workplace', 25, 60)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @firstSquareinSecondSquareInLeftFloorId, 180, 'workplace', 25, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @firstSquareinSecondSquareInLeftFloorId, 180, 'workplace', 50, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @secondSquareinSecondSquareInLeftFloorId, null, 'workplace', 50, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @secondSquareinSecondSquareInLeftFloorId, null, 'workplace', 25, 30)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId,'workplace', @wholeFloorId, 180, 'workplace', 10, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 10, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 35, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 60, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 10, 520)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 520)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 520)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 520)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 520)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 520)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 432)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 432)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 432)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 557)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 557)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 615)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 615)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 615)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 645)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 645)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 645)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 700)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId,'workplace', @wholeFloorId, 180, 'workplace', 205, 700)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 700)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 730)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 730)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 730)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 785)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 785)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 785)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 822)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 822)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 822)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 890)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 890)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 890)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 1200)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 1200)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 1200)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 1230)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 1230)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 1230)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 1280)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 1280)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 1310)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 1310)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 1310)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 180, 1360)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 205, 1360)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 230, 1360)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 180, 1390)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 205, 1390)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 230, 1390)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 10, 567)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 567)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 567)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 10, 597)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 35, 597)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 60, 597)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 10, 655)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 655)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 655)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 10, 685)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 35, 685)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 60, 685)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 10, 740)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 740)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 740)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 10, 770)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 35, 770)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 60, 770)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 10, 825)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 35, 825)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 60, 825)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 10, 855)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 35, 855)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 60, 855)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 20, 1185)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 45, 1185)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 70, 1185)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 20, 1230)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 45, 1230)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 70, 1230)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 20, 1260)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 45, 1260)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 70, 1260)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @tenthSquareInLeftFloorId, null, 'workplace', 80, 7)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @tenthSquareInLeftFloorId, 180, 'workplace', 20, 40)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @tenthSquareInLeftFloorId, 180, 'workplace', 45, 40)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @tenthSquareInLeftFloorId, null, 'workplace', 20, 70)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @tenthSquareInLeftFloorId, null, 'workplace', 45, 70)
	

		----------INSERT OBJECTS IN RIGHT FLOOR PART-----------------

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @fourthSquareInFirstSquareInRightFloorId, null, 'workplace', 50, 140)	

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @secondSquareInSecondSquareInRightFloorId, 180, 'workplace', 20, 58)	

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, @employee5Id, @floorId, 'workplace', @secondSquareInSecondSquareInRightFloorId, 180, 'workplace', 55, 58)	

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @fourthSquareInSecondSquareInRightFloorId, 180, 'workplace', 30, 58)	

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @fourthSquareInSecondSquareInRightFloorId, 180, 'workplace', 65, 58)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @thirdSquareInSecondSquareInRightFloorId, 180, 'workplace', 65, 103)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @thirdSquareInSecondSquareInRightFloorId, null, 'workplace', 100, 7)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 535, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 560, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 585, 440)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 535, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 560, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 585, 470)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 535, 555)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 560, 555)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 585, 555)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 535, 585)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 560, 585)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 535, 668)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 560, 668)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 585, 668)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 705, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 730, 440)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 755, 440)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 705, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 730, 470)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 755, 470)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 705, 535)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 730, 535)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 755, 535)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 705, 565)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 730, 565)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 755, 565)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 705, 635)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 730, 635)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 755, 635)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 705, 665)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 730, 665)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 755, 665)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, null, 'workplace', 10, 3)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, null, 'workplace', 35, 3)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, null, 'workplace', 60, 3)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, 180, 'workplace', 20, 40)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, 180, 'workplace', 50, 40)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, null, 'workplace', 20, 70)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @seventhSquareInRightFloorId, null, 'workplace', 50, 70)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 740, 1230)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 765, 1230)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 740, 1260)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 765, 1260)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 740, 1297)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 765, 1297)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 740, 1327)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 760, 1327)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 715, 1365)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 740, 1365)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, 180, 'workplace', 760, 1365)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 715, 1395)

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 740, 1395)
	
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'workplace', @wholeFloorId, null, 'workplace', 760, 1395)


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

		---Pievieno printerus---
INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'printer', @wholeFloorId, null, 'printer', 110, 20)
DECLARE @FirstPrinterId INT = @@IDENTITY

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@FirstPrinterId, N'Krāsains', 'colortype')

INSERT dbo.Objects (custom_height, custom_width, employee_id, floor_id, object_type_id, parent_object_id, rotation_angle, svg_type_id, top_left_x, top_left_y) VALUES
	(null, null, null, @floorId, 'printer', @wholeFloorId, null, 'printer', 148, 1350)
DECLARE @SecondPrinterId INT = @@IDENTITY

INSERT dbo.ObjectAttributes(object_id, value, attribute_id) VALUES
	(@SecondPrinterId, 'Melnbalts', 'colortype')