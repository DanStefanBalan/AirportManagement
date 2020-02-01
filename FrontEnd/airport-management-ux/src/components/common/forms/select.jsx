import React from "react";

const Select = ({
  name,
  label,
  onChange,
  options,
  error,
  value,
  rowType = "even"
}) => {
  return (
    <div className={"select-wrapper " + rowType}>
      <div className="select">
        <label htmlFor={name}>{label}</label>
        <select
          name={name}
          id={name}
          className={error && "has-error"}
          onChange={onChange}
          value={value}
        >
          {options.map(option => (
            <option key={option.id} value={option.name}>
              {option.name}
            </option>
          ))}
        </select>
      </div>
      <div className="error-wrapper">
        {error && <div className="error-message">{error}</div>}
      </div>
    </div>
  );
};

export default Select;
