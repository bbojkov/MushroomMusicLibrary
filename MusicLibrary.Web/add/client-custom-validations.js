function validateGenreString(sender, args) {
    var genre = args.Value,
     genreRegEx = '^[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$/i';

    if (genre.length < 2 && genre.length > 30) {
        args.IsValid = false;
        return;
    }

    if (!genre.match(genreRegEx)) {
        args.IsValid = false;
        return;
    }

    args.IsValid = true;
}