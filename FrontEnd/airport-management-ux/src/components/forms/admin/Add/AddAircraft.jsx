import React, { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPlaneDeparture } from "@fortawesome/free-solid-svg-icons";
import "../../../../styles/forms/addFlight.scss";
//resources
import minutes from "../../../../resources/images/min.png";
import hours from "../../../../resources/images/hr.png";
import data from "../../../../resources/content.json";
//common templates
import Input from "../../../common/forms/input";
import DoubleInput from "../../../common/forms/doubleinput";
import Select from "../../../common/forms/select";
//Schemas
import flightSchema from "../../../../schemas/flightSchema";

export default class AddAircraft extends Component {
  state = {
    dataForm: {
      aircraftType: "",
      countryOfRegistration: "",
      numberOfPilots: "",
      manufacturer: "",
      model: "",
      numberOfSeats: "",
      numberOfFlightAttendants: ""
    },
    errors: {}
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
        airline: dataForm.airline
      },
      options
    );

    if (!error) return null;
    for (let item of error.details) {
      errorMessage[item.path[0]] = item.message;
    }
    this.setState({ errors: errorMessage });
  };

  handleSubmit = e => {
    e.preventDefault();
    this.validate();
  };

  handleClick = e => {
    e.preventDefault();
    var dataForm = { ...this.state.dataForm };
    dataForm.status.value = "";
    dataForm.flightMinutesTime = "";
    dataForm.flightNumber = "";
    this.setState({ dataForm });
  };

  handleChange = ({ currentTarget: input }) => {
    const dataForm = { ...this.state.dataForm };
    dataForm[input.name] = input.value;
    this.setState({ dataForm });
  };

  setSelectValues = () => {
    return ["", "Value1", "Value2", "Value3", "Value4"];
  };

  render() {
    const coverage = this.setSelectValues();
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
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />
          <Input
            name={data.flight.flightNumber.name}
            label={data.flight.flightNumber.label}
            value={dataForm.flightNumber}
            onChange={this.handleChange}
            error={errors.flightNumber}
            rowType="odd"
          />

          <div className="bottom-section-wrapper">
            <button className="add-flight">
              {data.flight.submitButton.name}
            </button>
            <button className="clear-details" onClick={this.handleClick}>
              {data.flight.clearDataButton.name}
            </button>
          </div>
        </form>
      </div>
    );
  }
}
