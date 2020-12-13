import React, { Component } from "react";
import { Link } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlane } from "@fortawesome/free-solid-svg-icons";
import "../../../../styles/forms/addFlight.scss";
import { apiUrl } from "../../../../../src/config.json";
import {
  getCountries,
  saveResource,
  getResource,
} from "../../../../services/api";
//resources
import data from "../../../../resources/content.json";
//common templates
import Input from "../../../common/forms/input";
import Select from "../../../common/forms/select";
import aircraftSchema from "../../../../schemas/aircraftSchema";

const route = `${apiUrl}aircrafts`;
export default class AddAircraft extends Component {
  state = {
    dataForm: {
      flightId: "",
      aircraftNumber: "",
      countryOfRegistration: "",
      numberOfPilots: "",
      manufacturer: "",
      model: "",
      numberOfSeats: "",
      numberOfFlightAttendants: "",
    },
    updateForm: false,
    newlistOfCountries: [{ id: "", name: "" }],

    errors: {},
  };

  validate = () => {
    const dataForm = { ...this.state.dataForm };
    const errorMessage = {};
    const options = { abortEarly: false };
    const { error } = aircraftSchema.validate(
      {
        flightId: dataForm.flightId,
        aircraftNumber: dataForm.aircraftNumber,
        countryOfRegistration: dataForm.countryOfRegistration,
        numberOfPilots: dataForm.numberOfPilots,
        manufacturer: dataForm.manufacturer,
        model: dataForm.model,
        numberOfSeats: dataForm.numberOfSeats,
        numberOfFlightAttendants: dataForm.numberOfFlightAttendants,
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
    return error;
  };

  add = async () => {
    const aircraft = {
      flightId: this.state.dataForm.flightId,
      aircraftNumber: this.state.dataForm.aircraftNumber,
      countryOfRegistration: this.state.dataForm.countryOfRegistration,
      numberOfPilots: parseInt(this.state.dataForm.numberOfPilots),
      manufacturer: this.state.dataForm.manufacturer,
      model: this.state.dataForm.model,
      numberOfSeats: parseInt(this.state.dataForm.numberOfSeats),
      numberOfFlightAttendants: parseInt(
        this.state.dataForm.numberOfFlightAttendants
      ),
    };
    saveResource(aircraft, route);
  };

  update = async () => {
    const aircraft = {
      id: this.props.match.params.id,
      flightId: this.state.dataForm.flightId,
      aircraftNumber: this.state.dataForm.aircraftNumber,
      countryOfRegistration: this.state.dataForm.countryOfRegistration,
      numberOfPilots: parseInt(this.state.dataForm.numberOfPilots),
      manufacturer: this.state.dataForm.manufacturer,
      model: this.state.dataForm.model,
      numberOfSeats: parseInt(this.state.dataForm.numberOfSeats),
      numberOfFlightAttendants: parseInt(
        this.state.dataForm.numberOfFlightAttendants
      ),
    };
    saveResource(aircraft, route);
  };

  handleSubmit = (e) => {
    e.preventDefault();
    const error = this.validate();
    if (error === null) {
      if (this.state.updateForm === false) this.add();
      else {
        this.update();
      }
    }
  };

  createListOfCountries = (listOfCountries) => {
    var newlistOfCountries = [{ id: "", name: "" }];
    listOfCountries.map((item) => {
      var myobj = { id: item.name.toLowerCase(), name: item.name };
      newlistOfCountries.push(myobj);
    });
    return newlistOfCountries;
  };

  async swtichToUpdate(aircraftId) {
    if (aircraftId !== undefined) this.setState({ updateForm: true });
    if (this.state.updateForm !== false) {
      const { data: aircraftIdDetails } = await getResource(aircraftId, route);
      this.setState({ dataForm: this.mapToViewModel(aircraftIdDetails) });
    }
  }

  async componentDidMount() {
    const { data: listOfCountries } = await getCountries();
    const newlistOfCountries = this.createListOfCountries(listOfCountries);
    this.setState({ newlistOfCountries });
    const aircraftId = this.props.match.params.id;
    this.swtichToUpdate(aircraftId);
  }

  mapToViewModel(aircraft) {
    return {
      flightId: aircraft.flightId,
      aircraftNumber: aircraft.aircraftNumber,
      countryOfRegistration: aircraft.countryOfRegistration,
      numberOfPilots: aircraft.numberOfPilots,
      manufacturer: aircraft.manufacturer,
      model: aircraft.model,
      numberOfSeats: aircraft.numberOfSeats,
      numberOfFlightAttendants: aircraft.numberOfFlightAttendants,
    };
  }

  handleChange = ({ currentTarget: input }) => {
    const dataForm = { ...this.state.dataForm };
    dataForm[input.name] = input.value;
    this.setState({ dataForm });
  };

  render() {
    const { dataForm, errors, updateForm } = this.state;

    return (
      <div className="form-inner-content">
        <div className="header-section-wrapper">
          <div className="icon">
            <FontAwesomeIcon icon={faPlane} color="#763626" />
          </div>
          <div className="title">{data.aircraft.title}</div>
        </div>

        <form onSubmit={this.handleSubmit}>
          <Select
            name={data.aircraft.flightId.name}
            label={data.aircraft.flightId.label}
            value={dataForm.flightId}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.flightId}
          />
          <Input
            name={data.aircraft.aircraftNumber.name}
            label={data.aircraft.aircraftNumber.label}
            value={dataForm.numberOfPaircraftNumberilots}
            onChange={this.handleChange}
            error={errors.aircraftNumber}
            rowType="odd"
          />
          <Select
            name={data.aircraft.countryOfRegistration.name}
            label={data.aircraft.countryOfRegistration.label}
            value={dataForm.countryOfRegistration}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.countryOfRegistration}
          />
          <Input
            name={data.aircraft.numberOfPilots.name}
            label={data.aircraft.numberOfPilots.label}
            value={dataForm.numberOfPilots}
            onChange={this.handleChange}
            error={errors.numberOfPilots}
            rowType="odd"
          />
          <Input
            name={data.aircraft.manufacturer.name}
            label={data.aircraft.manufacturer.label}
            value={dataForm.manufacturer}
            onChange={this.handleChange}
            error={errors.manufacturer}
          />
          <Input
            name={data.aircraft.model.name}
            label={data.aircraft.model.label}
            value={dataForm.model}
            onChange={this.handleChange}
            error={errors.model}
            rowType="odd"
          />
          <Input
            name={data.aircraft.numberOfSeats.name}
            label={data.aircraft.numberOfSeats.label}
            value={dataForm.numberOfSeats}
            onChange={this.handleChange}
            error={errors.numberOfSeats}
          />
          <Input
            name={data.aircraft.numberOfFlightAttendants.name}
            label={data.aircraft.numberOfFlightAttendants.label}
            value={dataForm.numberOfFlightAttendants}
            onChange={this.handleChange}
            error={errors.numberOfFlightAttendants}
            rowType="odd"
          />
          <div className="bottom-section-wrapper">
            <button className="add-flight">
              {updateForm
                ? data.aircraft.updateButton.name
                : data.aircraft.submitButton.name}
            </button>
            <Link to="/admin/aircrafts">
              <button className="back-button">
                {data.aircraft.backButton.name}
              </button>
            </Link>
          </div>
        </form>
      </div>
    );
  }
}
