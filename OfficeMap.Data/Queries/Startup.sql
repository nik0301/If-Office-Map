DELETE FROM dbo.WorkplacesChanges;
DELETE FROM dbo.Floors WHERE title = N'6. stāvs';
DELETE FROM dbo.Floors WHERE title = N'7. stāvs';
DELETE FROM dbo.Attributes;
DELETE FROM dbo.Employees;
DELETE FROM dbo.Units;
DELETE FROM dbo.Objects;
DELETE FROM dbo.ObjectTypes;

---Pievieno atribūtus---
INSERT dbo.Attributes (id, name) VALUES
	('title', 'Nosaukums')

INSERT dbo.Attributes (id, name) VALUES
	('fridge', 'Ledusskapis')

INSERT dbo.Attributes (id, name) VALUES
	('microwave', N'Mikroviļnu krāsns')

INSERT dbo.Attributes (id, name) VALUES
	('dishmach', N'Trauku mašīna')

INSERT dbo.Attributes (id, name) VALUES
	('juicepress', N'Sulu spiede')

INSERT dbo.Attributes (id, name) VALUES
	('colortype', 'Veids')

	---Pievieno svg tipus---
DECLARE @workplaceId VARCHAR(10) = 'workplace'
DELETE FROM SvgTypes WHERE id = @workplaceId
INSERT dbo.SvgTypes (id, draw, fill_color, name, stroke_color, height, width) VALUES
	(@workplaceId, 'M 1 1 l 20 0 0 12 -20 0 0 -12 Z m 7 14 l 6 0 0 6 -6 0 0 -6 Z m 0 8 l 6 0 0 2 -6 0 0 -2 Z m -4 -6 l 2 0 0 4 -2 0 0 -4 Z m 12 0 l 2 0 0 4 -2 0 0 -4 Z', 'none', 'workplace', '#000000', 24, 20)

DECLARE @liftId VARCHAR(10) = 'lift'
DELETE FROM SvgTypes WHERE id = @liftId
INSERT dbo.SvgTypes (id, draw, fill_color, name, stroke_color, height, width) VALUES
	(@liftId, 'M 1 1 l 115 0 0 115 -115 0 0 -115 115 115 m 0 -115 l -115 115', 'none', 'lift', '#000000', 116, 116)

DECLARE @liftSecondId VARCHAR(10) = 'lift2'
DELETE FROM SvgTypes WHERE id = @liftSecondId
INSERT dbo.SvgTypes (id, draw, fill_color, name, stroke_color, height, width) VALUES
	(@liftSecondId, 'M 0 0 m 0 0 l 0 0 m 67 17 l 115 0 0 108 -115 0 0 -108 115 108 m 0 -108 l -115 108 m 0 0 l -66 0 a 1,1 0 0,1 246,0 l -66 0', 'none', 'lift', '#000000', 125, 248)

DECLARE @stairsId VARCHAR(10) = 'stairs'
DELETE FROM SvgTypes WHERE id = @stairsId
INSERT dbo.SvgTypes (id, draw, fill_color, name, stroke_color, height, width) VALUES
	(@stairsId, 'M 1 1 l 200 0 0 20 30 0 0 60 -30 0 0 20 -200 0 0 -35 200 0 0 -30 -200 0 0 -35 Z m 30 7 l 0 20 m 30 -20 l 0 20 m 30 -20 l 0 20 m 30 -20 l 0 20 m 30 -20 l 0 20 m -120 45 l 0 20 m 30 -20 l 0 20  m 30 -20 l 0 20 m 30 -20 l 0 20 m 30 -20 l 0 20', 'none', 'stairs', '#000000', 101, 231)

DECLARE @printerId VARCHAR(10) = 'printer'
DELETE FROM SvgTypes WHERE id = @printerId
INSERT dbo.SvgTypes (id, draw, fill_color, name, stroke_color, height, width) VALUES
	(@printerId, 'M 1 1 l 0 0 m 0 8 l 20 0 0 15 -6 0 0 -7 -8 0 0 7 -6 0 0 -15 m 9 0 l 0 -7 6 0 0 7 m -1 15 l 0 4 -8 0 0 -4', 'none', 'printer', '#000000', 28, 22)

---Pievieno objekta tipus---
INSERT dbo.ObjectTypes (id, name) VALUES
	('workplace', 'Darba vieta'),
	('meeting', N'Sapulču telpa'),
	('kitchen', 'Virtuve'),
	('wardrobe', 'Garderobe'),
	('wc', 'Tualete'),
	('printer', 'Printeris'),
	('lift', 'Lifts'),
	('stairs', N'Kāpnes'),
	('wall', 'Siena'),
	('colorWall', N'Iekrāsota siena')
		
		---Pievieno darbinieku nodaļas---
INSERT dbo.Units (id, name) VALUES
	('it', N'IT')

INSERT dbo.Units (id, name) VALUES
	('sales', N'Pārdošanas')

INSERT dbo.Units (id, name) VALUES
	('rem', N'Atlīdzību')

INSERT dbo.Units (id, name) VALUES
	('dev', N'Produktu attīstības un risku parakstīšanas daļa')

INSERT dbo.Units (id, name) VALUES
	('hr', N'HR')

INSERT dbo.Units (id, name) VALUES
	('actuary', N'Aktuāru')

INSERT dbo.Units (id, name) VALUES
	('audit', N'Iekšējais audits')

INSERT dbo.Units (id, name) VALUES
	('secretary', N'Sekretariāts')

INSERT dbo.Units (id, name) VALUES
	('marketing', N'Mārketings un Komunikācijas')

INSERT dbo.Units (id, name) VALUES
	('business', N'Biznesa kontrole')

INSERT dbo.Units (id, name) VALUES
	('lawyer', N'Juristu')

INSERT dbo.Units (id, name) VALUES
	('accounting', N'Grāmatvedība')

INSERT dbo.Units (id, name) VALUES
	('bus dev', N'Biznesa attīstība')