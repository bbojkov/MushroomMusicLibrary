function validateGenreString(sender, args) {
    var genre = args.Value,
     genreRegEx = '([A-Z])[a-z\- ]+';

    if (genre.length < 2 && genre.length > 20) {
        args.IsValid = false;
        return;
    }

    if (!genre.match(genreRegEx)) {
        args.IsValid = false;
        return;
    }

    args.IsValid = true;
}