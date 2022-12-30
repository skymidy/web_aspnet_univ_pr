import { Box, Button, Form, FormField, TextInput, Text } from "grommet";
import { useContext, useState } from "react";
import { Hide, View } from "grommet-icons";
import { useNavigate } from "react-router-dom";
import { AuthInput } from "../objects/AuthInput";
import { AuthInfo } from "../objects/AuthInfo";
import { AuthContext } from "../contexts/AuthContext";

const LoginForm = (props: any) => {
  const {login} = useContext(AuthContext);
  const [value, setValue] = useState({ login: "", password: "" });
  const [reveal, setReveal] = useState(false);
  const navigate = useNavigate();

  const handleLogin = (input: AuthInput) => {
    console.log(input);

    login(input).then((data: AuthInfo) => {
      if(data.isAuthenticated){
        navigate("/");
      }
    });
  };

  return (
    <Box fill align="center" justify="center">
      <Box width="medium" margin={{ horizontal: "large" }}>
        <Form
          value={value}
          onChange={(nextValue) => setValue(nextValue)}
          onSubmit={({ value: nextValue }) => handleLogin(nextValue)}
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

          <Box direction="column" margin={{ top: "medium" }}>
            <Button fill type="submit" label="Sign in" primary />
            <Text alignSelf="center" margin={{ vertical: "small" }}>
              or
            </Text>
            <Button
              onClick={() => {
                navigate("/registration");
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

export { LoginForm };
