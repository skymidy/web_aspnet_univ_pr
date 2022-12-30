import { Box, Button, Form, FormField, TextInput, Text } from "grommet";
import { useContext, useState } from "react";
import { Hide, View } from "grommet-icons";
import { useNavigate } from "react-router-dom";
import { AuthInput } from "../objects/AuthInput";
import { AuthContext } from "../contexts/AuthContext";
import { AuthInfo } from "../objects/AuthInfo";

const RegistrationForm = (props: any) => {
  const { registration } = useContext(AuthContext);

  //хуки данных
  const [value, setValue] = useState({
    login: "",
    password: "",
    rpassword: "",
  });

  //хуки состояния формы
  const [reveal, setReveal] = useState(false);
  const [disabledSubmit, setDisabledSubmit] = useState(true);
  const [error, setError] = useState({ login: "", password: "" });
  const [valid, setValid] = useState(false);

  const navigate = useNavigate();

  const handleRegistration = (input: AuthInput) => {
    console.log(input);

    registration(input).then((data: AuthInfo) => {
      if (data.isAuthenticated) {
        navigate("/profile");
      }
    });
  };

  return (
    <Box fill align="center" justify="center">
      <Box width="medium" margin={{ horizontal: "large" }}>
        <Form
          value={value}
          onChange={(nextValue) => {
            setValue(nextValue);
          }}
          onSubmit={({ value: nextValue }) => handleRegistration(nextValue)}
          validate="change"
          onValidate={(validationResults) => {
            setValid(validationResults.valid);
          }}
        >
          <FormField label="Login" name="login" required>
            <TextInput aria-label="login" name="login" type="text" />
          </FormField>
          <FormField label="Password" name="password" required>
            <Box direction="row">
              <TextInput
                focusIndicator={false}
                plain
                aria-label="password"
                name="password"
                type={reveal ? "text" : "password"}
              />
              <Button
                icon={reveal ? <View size="medium" /> : <Hide size="medium" />}
                onClick={() => setReveal(!reveal)}
              />
            </Box>
          </FormField>
          <FormField
            label="Repeat Password"
            name="rpassword"
            required
            validate={[
              {},
              () => {
                if (value.rpassword !== value.password)
                  return "Пароли не совпадаю!";
                return undefined;
              },
            ]}
          >
            <Box direction="row">
              <TextInput
                focusIndicator={false}
                plain
                aria-label="rpassword"
                name="rpassword"
                type={reveal ? "text" : "password"}
              />
              <Button
                icon={reveal ? <View size="medium" /> : <Hide size="medium" />}
                onClick={() => setReveal(!reveal)}
              />
            </Box>
          </FormField>

          <Box direction="column" margin={{ top: "medium" }}>
            <Button
              fill
              type="submit"
              label="Sign in"
              primary
              disabled={!valid}
            />
            <Text alignSelf="center" margin={{ vertical: "small" }}>
              or
            </Text>
            <Button
              onClick={() => {
                navigate("/auth");
              }}
              color="limegreen"
              fill="horizontal"
              type="button"
              label="Sign up"
              primary
            />
          </Box>
        </Form>
      </Box>
    </Box>
  );
};

export { RegistrationForm };
