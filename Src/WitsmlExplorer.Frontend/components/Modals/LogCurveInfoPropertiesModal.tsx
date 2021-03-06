import React, { useEffect, useState } from "react";
import { TextField } from "@material-ui/core";
import ModalDialog from "./ModalDialog";
import JobService, { JobType } from "../../services/jobService";
import OperationType from "../../contexts/operationType";
import RenameMnemonicJob from "../../models/jobs/renameMnemonicJob";
import { LogCurveInfoRow } from "../ContentViews/LogCurveInfoListView";
import { HideModalAction } from "../../contexts/operationStateReducer";

export interface LogCurveInfoPropertiesModalProps {
  logCurveInfo: LogCurveInfoRow;
  dispatchOperation: (action: HideModalAction) => void;
}

const LogCurveInfoPropertiesModal = (props: LogCurveInfoPropertiesModalProps): React.ReactElement => {
  const { logCurveInfo, dispatchOperation } = props;
  const [editableLogCurveInfo, setEditableLogCurveInfo] = useState<LogCurveInfoRow>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onSubmit = async () => {
    setIsLoading(true);
    const job: RenameMnemonicJob = {
      logReference: {
        wellUid: logCurveInfo.wellUid,
        wellboreUid: logCurveInfo.wellboreUid,
        logUid: logCurveInfo.logUid
      },
      mnemonic: logCurveInfo.mnemonic,
      newMnemonic: editableLogCurveInfo.mnemonic
    };
    await JobService.orderJob(JobType.RenameMnemonic, job);
    setIsLoading(false);
    dispatchOperation({ type: OperationType.HideModal });
  };

  useEffect(() => {
    setEditableLogCurveInfo(logCurveInfo);
  }, [logCurveInfo]);

  return (
    <>
      {editableLogCurveInfo && (
        <ModalDialog
          confirmDisabled={logCurveInfo.mnemonic == editableLogCurveInfo.mnemonic}
          heading={`Edit properties for LogCurve: ${editableLogCurveInfo.mnemonic}`}
          content={
            <>
              <TextField disabled id="uid" label="uid" defaultValue={editableLogCurveInfo.uid} fullWidth />
              <TextField
                id="mnemonic"
                label="mnemonic"
                defaultValue={editableLogCurveInfo.mnemonic}
                error={editableLogCurveInfo.mnemonic.length === 0}
                helperText={editableLogCurveInfo.mnemonic.length === 0 ? "A logCurveInfo mnemonic must be 1-64 characters" : ""}
                fullWidth
                inputProps={{ minLength: 1, maxLength: 64 }}
                onChange={(e) => setEditableLogCurveInfo({ ...editableLogCurveInfo, mnemonic: e.target.value })}
              />
            </>
          }
          onSubmit={() => onSubmit()}
          isLoading={isLoading}
        />
      )}
    </>
  );
};

export default LogCurveInfoPropertiesModal;
