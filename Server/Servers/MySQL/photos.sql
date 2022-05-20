create table photos
(
    source    text     not null,
    caption   text null,
    user_from text     not null,
    user_to   text     not null,
    time      datetime not null
);