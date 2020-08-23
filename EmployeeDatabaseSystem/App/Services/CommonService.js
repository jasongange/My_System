
angular.module("mainApp").factory('CommonService', ['$http', '$q', function ($http, $q) {
    return {
        successMessage: function (message) {
            swal({
                title: message,
                type: "success",
                showConfirmButton: false,
                timer: 3000,
            });
        },
        //errorMessage: function (error) {
        //    toastr["error"](error, "Error");
        //},
        //warningMessage: function (error) {
        //    toastr["warning"](error, "Warning");
        //},

        saveChanges: function (callbackFunction) {
            swal({
                title: "Save changes.",
                text: "Are you sure to save this changes?",
                type: "info",
                showCancelButton: true,
                confirmButtonColor: "#1ab394",
                confirmButtonText: "Yes proceed",
                closeOnConfirm: true
            },callbackFunction
           );
        },
    };
}]);