EXTERNAL addNewSubcharacter(name,color,pictureName)
EXTERNAL setMainCharacter(name,color,pictureName)

VAR location="mansion"

~setMainCharacter("Ненси","236,151,31,255","Nancy")
~addNewSubcharacter("Эллен","0,150,255,255","Elen") 

::Телефон, стоявший в прихожей, зазвонил. Нэнси Дрю взбежала по ступенькам крыльца, а оттуда кинулась в прихожую, по дороге стаскивая с рук садовые перчатки.

~location="mainHouse"

Ненси::Алло! #mainCharacter
Эллен::Нэнси, привет! Это Эллен.#subCharacter
::Хотя Эллен Корнинг была почти на три года старше Нэнси, между девушками установилась тесная дружба.
Эллен::Ты сейчас ни над каким делом не работаешь? #subCharacter
Ненси::Нет. А что случилось? Опять какая-нибудь загадочная история? #mainCharacter

- -> END