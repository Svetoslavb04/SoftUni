function sortArray(array, sorting) {
    if (sorting == 'asc') {
        return array.sort((a, b) => a - b);
    } else if (sorting == 'desc') {
        return array.sort((a, b) => b - a);
    }
}