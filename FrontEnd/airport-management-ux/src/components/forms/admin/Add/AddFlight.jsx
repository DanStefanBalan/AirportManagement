import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlaneDeparture } from "@fortawesome/free-solid-svg-icons";
import "../../../../styles/forms/addFlight.scss";
import {
  getCountries,
  saveResource,
  getResource,
  getAircraftsNumber,
} from "../../../../services/api";
import { apiUrl } from "../../../../config.json";
//resources
import minutes from "../../../../resources/images/min.png";
import hours from "../../../../resources/images/hr.png";
import data from "../../../../resources/content.json";
//common templates
import Input from "../../../common/forms/input";
import Select from "../../../common/forms/select";
import flightSchema from "../../../../schemas/flightSchema";
import DoubleInput from "./../../../common/forms/doubleinput";

const flightRoute = `${apiUrl}flights`;

export default class AddAirport extends Component {
  state = {
    dataForm: {
      flightNumber: "",
      aircraft: "",
      destination: "",
      estimationHoursTime: "",
      estimationMinutesTime: "",
      arrivalMinutesTime: "",
      arrivalHoursTime: "",
      departureMinutesTime: "",
      departureHoursTime: "",
      flightMinutesTime: "",
      flightHoursTime: "",
      status: "",
      gate: "",
      airline: "",
    },
    newlistOfCountries: [{ id: "", name: "" }],
    newlistofAircraftNumber: [{ id: "", name: "" }],
    errors: {},
  };

  validate = () => {
    const dataForm = { ...this.state.dataForm };
    const errorMessage = {};
    const options = { abortEarly: false };
    const { error } = flightSchema.validate(
      {
        flightNumber: dataForm.flightNumber,
        aircraft: dataForm.aircraft,
        destination: dataForm.destination,
        estimationHoursTime: dataForm.estimationHoursTime,
        estimationMinutesTime: dataForm.estimationMinutesTime,
        arrivalHoursTime: dataForm.arrivalHoursTime,
        arrivalTimeMinutesTime: dataForm.departureMinutesTime,
        departureHoursTime: dataForm.departureHoursTime,
        departureMinutesTime: dataForm.departureMinutesTime,
        flightHoursTime: dataForm.flightHoursTime,
        flightMinutesTime: dataForm.flightMinutesTime,
        status: dataForm.status,
        gate: dataForm.gate,
        airline: dataForm.airline,
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
  };

  add = async () => {
    const flight = {
      flightNumber: this.state.dataForm.flightNumber,
      aircraft: this.state.dataForm.aircraft,
      destination: this.state.dataForm.destination,
      estimationHoursTime: this.state.dataForm.estimationHoursTime,
      estimationMinutesTime: this.state.dataForm.estimationMinutesTime,
      arrivalHoursTime: this.state.dataForm.arrivalHoursTime,
      arrivalTimeMinutesTime: this.state.dataForm.departureMinutesTime,
      departureHoursTime: this.state.dataForm.departureHoursTime,
      departureMinutesTime: this.state.dataForm.departureMinutesTime,
      flightHoursTime: this.state.dataForm.flightHoursTime,
      flightMinutesTime: this.state.dataForm.flightMinutesTime,
      status: this.state.dataForm.status,
      gate: this.state.dataForm.gate,
      airline: this.state.dataForm.airline,
    };
    saveResource(flight, flightRoute);
  };

  update = async () => {
    const flight = {
      flightNumber: this.state.dataForm.flightNumber,
      aircraft: this.state.dataForm.aircraft,
      destination: this.state.dataForm.destination,
      estimationHoursTime: this.state.dataForm.estimationHoursTime,
      estimationMinutesTime: this.state.dataForm.estimationMinutesTime,
      arrivalHoursTime: this.state.dataForm.arrivalHoursTime,
      arrivalTimeMinutesTime: this.state.dataForm.departureMinutesTime,
      departureHoursTime: this.state.dataForm.departureHoursTime,
      departureMinutesTime: this.state.dataForm.departureMinutesTime,
      flightHoursTime: this.state.dataForm.flightHoursTime,
      flightMinutesTime: this.state.dataForm.flightMinutesTime,
      status: this.state.dataForm.status,
      gate: this.state.dataForm.gate,
      airline: this.state.dataForm.airline,
    };
    saveResource(flight, flightRoute);
  };

  handleSubmit = (e) => {
    e.preventDefault();
    this.validate();
    if (this.state.updateForm === false) this.add();
    else {
      this.update();
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

  createListOfAircraftNumber = (listofAircraftNumber) => {
    var newlistofAircraftNumber = [{ id: "", name: "" }];
    let id = 1;
    listofAircraftNumber.map((item) => {
      let myobj = { id: id, name: item };
      newlistofAircraftNumber.push(myobj);
      id += 1;
    });
    return newlistofAircraftNumber;
  };

  async swtichToUpdate(flightId) {
    if (flightId !== undefined) this.setState({ updateForm: true });
    if (this.state.updateForm !== false) {
      const { data: flightDetails } = await getResource(flightId);
      this.setState({ dataForm: this.mapToViewModel(flightDetails) });
    }
  }

  async componentDidMount() {
    const { data: listOfAircraftNumbers } = await getAircraftsNumber();
    const newlistofAircraftNumber = this.createListOfAircraftNumber(
      listOfAircraftNumbers
    );
    const { data: listOfCountries } = await getCountries();
    const newlistOfCountries = this.createListOfCountries(listOfCountries);
    this.setState({ newlistOfCountries, newlistofAircraftNumber });
    const airportId = this.props.match.params.id;
    this.swtichToUpdate(airportId);
  }

  mapToViewModel(airport) {
    return {
      name: airport.name,
      country: airport.country,
      city: airport.city,
    };
  }

  handleClick = (e) => {
    e.preventDefault();
    this.setState({
      dataForm: {
        name: "",
        country: "",
        city: "",
      },
    });
  };

  handleChange = ({ currentTarget: input }) => {
    const dataForm = { ...this.state.dataForm };
    dataForm[input.name] = input.value;
    this.setState({ dataForm });
  };

  render() {
    const { dataForm, errors } = this.state;

    return (
      <div className="form-inner-content">
        <div className="header-section-wrapper">
          <div className="icon">
            <FontAwesomeIcon icon={faPlaneDeparture} color="#763626" />
          </div>
          <div className="title">{data.flight.title}</div>
        </div>
        <form onSubmit={this.handleSubmit}>
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Select
            name={data.flight.aircraft.name}
            label={data.flight.aircraft.label}
            value={dataForm.aircraft}
            onChange={this.handleChange}
            options={this.state.newlistofAircraftNumber}
            error={errors.aircraft}
          />
          <Select
            name={data.flight.destination.name}
            label={data.flight.destination.label}
            value={dataForm.destination}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.destination}
            rowType="odd"
          />
          <DoubleInput
            label={data.flight.estimationTime.label}
            name1={data.flight.estimationTime.name1}
            name2={data.flight.estimationTime.name2}
            value1={dataForm.estimationHoursTime}
            value2={dataForm.estimationMinutesTime}
            onChange={this.handleChange}
            error1={errors.estimationHoursTime}
            error2={errors.estimationMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
          />
          <DoubleInput
            label={data.flight.arrivalTime.label}
            name1={data.flight.arrivalTime.name1}
            name2={data.flight.arrivalTime.name2}
            value1={dataForm.arrivalHoursTime}
            value2={dataForm.arrivalMinutesTime}
            onChange={this.handleChange}
            error1={errors.arrivalHoursTime}
            error2={errors.arrivalMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
            rowType="odd"
          />
          <DoubleInput
            label={data.flight.departureTime.label}
            name1={data.flight.departureTime.name1}
            name2={data.flight.departureTime.name2}
            value1={dataForm.departureHoursTime}
            value2={dataForm.departureMinutesTime}
            onChange={this.handleChange}
            error1={errors.departureHoursTime}
            error2={errors.departureMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
          />
          <DoubleInput
            label={data.flight.flightTime.label}
            name1={data.flight.flightTime.name1}
            name2={data.flight.flightTime.name2}
            value1={dataForm.flightHoursTime}
            value2={dataForm.flightMinutesTime}
            onChange={this.handleChange}
            error1={errors.flightHoursTime}
            error2={errors.flightMinutesTime}
            background1={hours}
            background2={minutes}
            type="number"
            rowType="odd"
          />
          <Select
            name={data.flight.status.name}
            label={data.flight.status.label}
            value={dataForm.status}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.status}
          />
          <Select
            name={data.flight.gate.name}
            label={data.flight.gate.label}
            value={dataForm.gate}
            onChange={this.handleChange}
            options={this.state.newlistOfCountries}
            error={errors.gate}
            rowType="odd"
          />
          <Input
            name={data.flight.airline.name}
            label={data.flight.airline.label}
            value={dataForm.airline}
            onChange={this.handleChange}
            error={errors.airline}
          />
          <div className="bottom-section-wrapper">
            <button className="add-flight">
              {data.flight.submitButton.name}
            </button>
            <button className="clear-details" onClick={this.handleClick}>
              {data.flight.backButton.name}
            </button>
          </div>
        </form>
      </div>
    );
  }
}
