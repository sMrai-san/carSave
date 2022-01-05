import axios from "axios";

const apiUrl = "http://94.237.113.71:5011/api/cardata/";

class ApiCall {

    loadCars() {
        return axios.get(apiUrl);
    }

    addCar(car) {
        return axios.post(apiUrl, car);
    }

    deleteCar(row) {
        return axios.delete(apiUrl + row.carId);
    }
}

export default new ApiCall();