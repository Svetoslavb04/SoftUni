
exports.globalErrorHandler = function(error, req, res, next) {
    res.render('404', {
        error
    })
}