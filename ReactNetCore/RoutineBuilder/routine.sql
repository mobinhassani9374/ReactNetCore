DECLARE @RoutineId int =230000;
DECLARE @RoutineTitle NVARCHAR(MAX) = N'روال گزینش مصاحبه';
DECLARE @RoutineTableName VARCHAR(MAX) = 'InterviewChoice';

-- delete old datas
DELETE [RoutineRole] WHERE [RoutineId] = @RoutineId
DELETE [RoutineStep] WHERE [RoutineId] = @RoutineId
DELETE [RoutineAction] WHERE [RoutineId] = @RoutineId


-- Create Routine
if exists (select * from [Routine] with (updlock,serializable) where [Id] = @RoutineId)
begin
   UPDATE [Routine] set
		[Title] = @RoutineTitle
	  , [TableName] = @RoutineTableName
   WHERE [Id] = @RoutineId
end
else
begin
    SET IDENTITY_INSERT [Routine] ON
    INSERT INTO [Routine] (
          [Id]
        , [Title]
        , [TableName]
    )

    VALUES (
          @RoutineId
        , @RoutineTitle
        , @RoutineTableName
    )
    SET IDENTITY_INSERT [Routine] OFF
end



-- Create RoutineRoles
INSERT INTO [RoutineRole] (
	[RoutineId],    [SortOrder],       [DashboardEnum],             [Title],                         [StepsJson]) VALUES
	(@RoutineId,        '1',            'Expert',                N'کارشناس',						 '["100"]');


-- Create RoutineSteps
INSERT INTO [RoutineStep] (
	  [RoutineId],        [Step],         [F1],        [F2],        [F3],        [F4],      [F5],      [F6],     [F7],      [Title] )    VALUES
      (@RoutineId,         100,           NULL,         110,         120,         NULL,      NULL,      NULL,     NULL,      N'بررسی توسط کارشناس')
	 ,(@RoutineId,         110,           NULL,         NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'تایید و اتمام گزینش')     
	 ,(@RoutineId,         120,           NULL,         NULL,        NULL,        NULL,      NULL,      NULL,     NULL,      N'رد و اتمام گزینش')

;								        																	  
						
						
-- Create Actions Information
INSERT INTO [RoutineAction] (
       [RoutineId],   [Step],      [Action],             [Color],           [Icon],                [Title]) VALUES
      
	  (@RoutineId,    100,         'F2',                                         'success',         'check',				  N'تایید')
	 , (@RoutineId,    100,         'F3',                                        'danger',          'close-circle',        N'رد') 



SELECT * FROM Routine WHERE Id = @RoutineId
SELECT * FROM RoutineRole WHERE RoutineId = @RoutineId
SELECT * FROM RoutineStep WHERE RoutineId = @RoutineId
SELECT * FROM RoutineAction WHERE RoutineId = @RoutineId