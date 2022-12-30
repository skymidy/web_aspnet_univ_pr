import {
  Layer,
  Box,
  Button,
  Header,
  FormField,
  TextInput,
  CheckBox,
  TextArea,
  Form,
  Text,
} from "grommet";
import { FormClose } from "grommet-icons";
import { useEffect, useState } from "react";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { ProfileInfo } from "../objects/ProfileInfo";
import { ProfileInput } from "../objects/ProfileInput";
import { profileRepository } from "../repositories/ProfileRepository";

export const ProfileForm = (props: any) => {
  const params = useParams();
  const [message, setMessage] = useState("");
  const [messageColor, setMessageColor] = useState("");

  useEffect(() => {
    profileRepository.getProfile(params["*"]).then((data) => {
      handleData(data);
    });
  }, []);

  const handleData = (data: ProfileInfo) => {
    setValue(data.userProfile);
  };

  const [value, setValue] = useState<ProfileInput>();
  const [showForm, setShowForm] = useState(false);

  const onOpen = () => setShowForm(true);

  const onClose = () => setShowForm(false);

  const handleUpdateProfile = (input: ProfileInput) => {
    profileRepository.updateProfile(input).then((data) => {
      if (data.errorMessage === "") {
        setMessage("Успешно");
        setMessageColor("green");
        setTimeout(() => {
          window.location.reload();
        }, 2000);
      } else {
        setMessage(data.errorMessage);
        setMessageColor("red");
      }
    });
  };
  return (
    <>
      <Box margin={{ top: "medium" }}>
        <Button fill type="button" label="Edit" onClick={onOpen} />
      </Box>
      {showForm && (
        <Layer modal onClickOutside={onClose} onEsc={onClose}>
          <Box
            width="medium"
            margin={{ horizontal: "large", vertical: "medium" }}
          >
            <Header justify="end">
              <Box background={messageColor}>
                <Text color="white">{message}</Text>
              </Box>
              <Button type="button" onClick={onClose}>
                <FormClose />
              </Button>
            </Header>
            <Form
              value={value}
              onChange={(nextValue) => setValue(nextValue)}
              onSubmit={({ value: nextValue }) =>
                handleUpdateProfile(nextValue)
              }
            >
              <FormField label="Knowledge" name="knowledge" required>
                <TextInput
                  aria-label="knowledge"
                  name="knowledge"
                  type="text"
                />
              </FormField>
              <FormField label="Interests" name="interests" required>
                <TextInput
                  aria-label="interests"
                  name="interests"
                  type="text"
                />
              </FormField>

              <FormField>
                <CheckBox label="В поиске" name="searchStatus" />
                <CheckBox label="Ищу ментора" name="mentorSearchStatus" />
                <CheckBox label="Я ментор" name="mentorStatus" />
              </FormField>
              <FormField label="Description" name="description">
                <TextArea
                  aria-label="description"
                  name="description"
                  resize={"vertical"}
                />
              </FormField>
              <Box direction="column" margin={{ top: "medium" }}>
                <Button fill type="submit" label="Update" primary />
              </Box>
            </Form>
          </Box>
        </Layer>
      )}
    </>
  );
};
