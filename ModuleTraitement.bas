Attribute VB_Name = "ModuleTraitement"
Sub macroTraitement()
    'Initialisation des variables
    '''''''''''''''''''''''''''''
    Dim ws_1, ws_2 As Worksheet
    Dim i, j As Integer
    Dim unLibelle, libelleComp As String
        'Saisie des feuilles à traiter
        feuilleTrait = InputBox("Saisir le nom de la feuille excel à traiter (en respectant les majuscules) : ")
        feuilleRef = InputBox("Saisir le nom de la feuille excel de référence des comptes (en respectant les majuscules) : ")
        donneeColonne = InputBox("Saisir le nom à insérer dans la colonne B : ")
	ligneDebut = Val(InputBox("Saisir la ligne de début : "))
        
    Set ws_1 = Worksheets(feuilleTrait)
    Set ws_2 = Worksheets(feuilleRef)
    i = ligneDebut
    
    'Préparation du fichier
    '''''''''''''''''''''''
    'Insertion de 3 colonnes supplémentaires + décalage à droite
    ws_1.Columns("C:E").Insert Shift:=xlToRight
    'formate les cellules en format TEXTE
    ws_1.Columns("C:E").NumberFormat = "@"
    ws_1.Columns("C:E").ColumnWidth = 13 '96 pixels
    
    'Traitement des lignes
    ''''''''''''''''''''''
    Do While ws_1.Cells(i, 6).Value <> ""
        'On met la valeur du libellé à parcourir dans une variable
        unLibelle = ws_1.Cells(i, 6).Value
        'On réinitialise la recherche dans le tableau de référence
        j = 2
        'On parcours le tableau de référence des comptes bancaires
        Do While ws_2.Cells(j, 2).Value <> ""
            libelleComp = ws_2.Cells(j, 2).Value
			'Mise des libellés en Majuscule
			libelleCompMaju = UCase(libelleComp)
			unLibelleMaju = UCase(unLibelle)
			
			'Remplacement des espaces par des * :
			'comme ca, peut importe la position des mots dans les libellés
			libelleComp = Replace(libelleComp, " ", "*")
			libelleCompMaju = Replace(libelleCompMaju, " ", "*")
			
            'On teste la variable avec le tableau de référence
            If ( (unLibelle Like "*" & libelleComp & "*") Or (unLibelleMaju Like "*" & libelleCompMaju & "*") ) Then
                ws_1.Cells(i, 4).Value = ws_2.Cells(j, 1)
                ws_1.Cells(i, 3).Value = donneeColonne
                ws_1.Cells(i, 5).Value = ws_2.Cells(j, 3)
            End If
            j = j + 1
        Loop
        i = i + 1
    Loop
End Sub
