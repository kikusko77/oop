SELECT * FROM Student LEFT JOIN studentPredmet ON Student.Id_studenta = studentPredmet.Id_studenta	LEFT JOIN Predmet ON Predmet.Skratka=studentPredmet.Skratka
