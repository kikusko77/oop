SELECT p.Skratka, p.NazovPredmetu
FROM Predmet p
WHERE (SELECT COUNT(*) FROM studentPredmet sp WHERE sp.Skratka = p.Skratka) < 3
