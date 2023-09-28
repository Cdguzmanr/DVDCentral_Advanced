begin 
	Insert into tblMovie (Id, Title, Description, FormatId, DirectorId, RatingId, Cost, InStkQty, ImagePath)
	values 
	(1, 'The Great Escape', 'A war film about a prison escape.', 1, 1, 1, 19.99, 100, '/images/great_escape.jpg'),
    (2, 'Pulp Fiction', 'A crime drama with interconnected stories.', 2, 2, 2, 24.99, 50, '/images/pulp_fiction.jpg'),
    (3, 'The Dark Knight', 'A superhero film about Batman.', 3, 3, 3, 29.99, 75, '/images/dark_knight.jpg');
end 